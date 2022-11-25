using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
  public class BrandManager : IBrandService
  {
    IBrandDal _brandDal;
    public BrandManager(IBrandDal brandDal)
    {
      _brandDal = brandDal;
    }

    [ValidationAspect(typeof(BrandValidator))]
    public IResult Add(Brand brand)
    {
      var result = BusinessRules.Run(CheckIfBrandNameExists(brand.Name));
      if(result != null)
      {
        return result;
      }
      _brandDal.Add(brand);
      return new SuccessResult(Messages.BrandAdded);
    }

    public IResult Delete(Brand brand)
    {
      _brandDal.Delete(brand);
      return new SuccessResult(Messages.BrandDeleted);
    }

    public IDataResult<List<Brand>> GetAll()
    {
      return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
    }

    public IDataResult<Brand> GetById(int brandId)
    {
      return new SuccessDataResult<Brand>( _brandDal.Get(b => b.Id == brandId));
    }


    [ValidationAspect(typeof(BrandValidator))]
    public IResult Update(Brand brand)
    {
      _brandDal.Update(brand);
      return new SuccessResult(Messages.BrandUpdated);
    }
    #region Rules
    private IResult CheckIfBrandNameExists(string brandName)
    {
      var result = _brandDal.GetAll(b => b.Name == brandName).Count;
      if(result > 0 )
      {
        return new ErrorResult(Messages.BrandNameAlreadyExists);
      }
      return new SuccessResult();
    }

    #endregion
  }
}
