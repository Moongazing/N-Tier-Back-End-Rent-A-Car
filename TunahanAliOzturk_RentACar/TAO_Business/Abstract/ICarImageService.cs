using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;
using TAO_Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace TAO_Business.Abstract
{
  public interface ICarImageService
  {
    IResult Add(IFormFile file, CarImage carImage);
    IResult Delete(CarImage carImage);
    IResult Update(IFormFile file, CarImage carImage);
    IDataResult<List<CarImage>> GetAll();
    IDataResult<CarImage> GetById(int imageId);
  }
}
