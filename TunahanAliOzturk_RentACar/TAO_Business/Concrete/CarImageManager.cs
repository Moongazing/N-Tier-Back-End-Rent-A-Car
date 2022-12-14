using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Business.Abstract;
using TAO_Business.Constants;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Helpers.FileHelper;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;
using TAO_Core.Utilities.Results;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;

namespace TAO_Business.Concrete
{
  public class CarImageManager : ICarImageService
  {
    ICarImageDal _carImageDal;
    IFileHelper _fileHelper;
    public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
    {
      _carImageDal = carImageDal;
      _fileHelper = fileHelper;
    }
    public IResult Add(IFormFile file, CarImage carImage)
    {
      IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
      if (result != null)
      {
        return result;
      }
      carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
      carImage.Date = DateTime.Now;
      _carImageDal.Add(carImage);
      return new SuccessResult(Messages.CarAdded);
    }
    public IResult Delete(CarImage carImage)
    {
      _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
      _carImageDal.Delete(carImage);
      return new SuccessResult();
    }
    public IResult Update(IFormFile file, CarImage carImage)
    {
      carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
      _carImageDal.Update(carImage);
      return new SuccessResult();
    }

    public IDataResult<List<CarImage>> GetByCarId(int carId)
    {
      var result = BusinessRules.Run(CheckCarImage(carId));
      if (result != null)
      {
        return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
      }
      return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
    }

    public IDataResult<CarImage> GetById(int imageId)
    {
      return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
    }

    public IDataResult<List<CarImage>> GetAll()
    {
      return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }
    private IResult CheckIfCarImageLimit(int carId)
    {
      var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
      if (result > 5)
      {
        return new ErrorResult(Messages.CarNumberExceeded);
      }
      return new SuccessResult();
    }
    public IDataResult<List<CarImage>> GetDefaultImage(int carId)
    {

      List<CarImage> carImage = new List<CarImage>();
      carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
      return new SuccessDataResult<List<CarImage>>(carImage);
    }
    private IResult CheckCarImage(int carId)
    {
      var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
      if (result > 0)
      {
        return new SuccessResult();
      }
      return new ErrorResult();
    }
  }
}
