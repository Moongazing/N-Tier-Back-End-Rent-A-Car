using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Entities.Concrete;
using TAO_Entities.DTOs;

namespace TAO_Business.Abstract
{
  public interface ICarService
  {
    IDataResult<List<Car>> GetAll();
    IDataResult<List<Car>> GetByBrandId(int brandId);
    IDataResult<List<Car>> GetByColorId(int colorId);
    IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
    IDataResult<List<CarDetailDto>> GetCarDetails();
    IDataResult<Car> GetById(int carId);
    IResult Add(Car car);
    IResult Delete(Car car);
    IResult Update(Car car);
    IResult AddTransactionalTest(Car car);

  }
}
