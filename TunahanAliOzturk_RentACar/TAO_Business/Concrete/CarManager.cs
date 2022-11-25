using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TAO_Business.Abstract;
using TAO_Business.BussinesAspects.Autofac;
using TAO_Business.Constants;
using TAO_Business.ValidationRules.FluentValidation;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Transaction;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.CrossCuttingConcerns.Validation;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;
using TAO_Entities.DTOs;

namespace TAO_Business.Concrete
{
  public class CarManager : ICarService
  {
    ICarDal _carDal;
    IRentalService _rentalService;
    public CarManager(ICarDal carDal, IRentalService rentalService)
    {
      _carDal = carDal;
      _rentalService = rentalService;
    }

    [SecuredOperation("car.add,admin")]
    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]

    public IResult Add(Car car)
    {
      var result = BusinessRules.Run(CheckIfRentalLimitExceded());
      _carDal.Add(car);
      return new SuccessResult(Messages.CarAdded);
    }

    [CacheAspect]
    public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
    {
      if (DateTime.Now.Hour == 22)
      {
        return new ErrorDataResult<List<Car>>(Messages.MaintenceTime);
      }
      return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
    }

    [SecuredOperation("admin")]
    public IResult Delete(Car car)
    {
      _carDal.Delete(car);
      return new SuccessResult(Messages.CarDeleted);
    }

    [CacheAspect]
    public IDataResult<List<Car>> GetAll()
    {
      return new DataResult<List<Car>>(_carDal.GetAll(), true);
    }

    [CacheAspect]
    public IDataResult<List<Car>> GetByBrandId(int brandId)
    {
      return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
    }

    [SecuredOperation("admin")]
    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Update(Car car)
    {
      _carDal.Update(car);
      return new SuccessResult(Messages.CarUpdated);
    }
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<List<Car>> GetByColorId(int colorId)
    {
      return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
      return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
    }

    public IDataResult<Car> GetById(int carId)
    {
      return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
    }

    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Car car)
    {
      throw new NotImplementedException();
    }

    private IResult CheckIfRentalLimitExceded()
    {
      var result = _rentalService.GetAll();
      if (result.Data.Count > 200)
      {
        return new ErrorResult(Messages.RentalLimitExceded);
      }
      return new SuccessResult();
    }

   
  }
}
