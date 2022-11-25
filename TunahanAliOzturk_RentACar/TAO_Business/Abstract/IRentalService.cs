using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;
using TAO_Entities.Concrete;
using TAO_Entities.DTOs;

namespace TAO_Business.Abstract
{
  public interface IRentalService
  {
    IDataResult<List<Rental>> GetAll();
    IDataResult<List<Rental>> AvailableDate(DateTime min, DateTime max);
    //IDataResult<List<CarDetailDto>> GetCarDetails();
    IDataResult<Rental> GetById(int rentalId);
    IResult Add(Rental rental);
    IResult Delete(Rental rental);
    IResult Update(Rental rental);
  }
}
