using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAO_Business.Abstract;
using TAO_Business.Constants;
using TAO_Business.ValidationRules.FluentValidation;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;

namespace TAO_Business.Concrete
{
  public class RentalManager : IRentalService
  {
    IRentalDal _rentalDal;
    public RentalManager(IRentalDal rentalDal)
    {
      _rentalDal = rentalDal;
    }

    //[SecuredOperation("rental.add")]
    [ValidationAspect(typeof(RentalValidator))]
    public IResult Add(Rental rental)
    {
      var result = BusinessRules.Run(CheckReturnDateForAvailableCar(rental.CarId));
                                    

      if (result != null)
      {
        return result;
      }
      _rentalDal.Add(rental);

      return new SuccessResult(Messages.RentalAdded);

      // return new ErrorResult(Messages.NotAvailableCarForRental);

    }

    public IDataResult<List<Rental>> AvailableDate(DateTime min, DateTime max)
    {
      return new SuccessDataResult<List<Rental>>();
    }

    public IResult Delete(Rental rental)
    {
      _rentalDal.Delete(rental);
      return new SuccessResult(Messages.RentalDeleted);
    }

    public IDataResult<List<Rental>> GetAll()
    {
      return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(int rentalId)
    {
      return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
    }

    [ValidationAspect(typeof(RentalValidator))]
    public IResult Update(Rental rental)
    {
      _rentalDal.Update(rental);
      return new SuccessResult();
    }

    #region
    private IResult CheckReturnDateForAvailableCar(int carId)
    {
      var result = _rentalDal.GetAll(r => r.ReturnDate == null).Where(r => r.CarId == carId);
      return new ErrorResult(Messages.NotAvailableCarForRental);
    }
    

    #endregion
  }
}
