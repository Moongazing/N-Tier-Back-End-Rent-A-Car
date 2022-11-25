using System;
using System.Collections.Generic;
using System.Drawing;
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
using TAO_DataAccess.Concrete.EntityFramework;
using TAO_Entities.Concrete;

namespace TAO_Business.Concrete
{
  public class ColourManager : IColourService
  {
    IColourDal _colorDal;
    public ColourManager(IColourDal colorDal)
    {
      _colorDal = colorDal;
    }

    [ValidationAspect(typeof(ColourValidator))]
    public IResult Add(Colour colour)
    {
      var result = BusinessRules.Run(CheckIfColorlExists(colour.Name));

      if(result != null)
      {
        return result;
      }
      _colorDal.Add(colour);
      return new SuccessResult(Messages.ColorAdded);
    }

    public IResult Delete(Colour colour)
    {
      _colorDal.Delete(colour);
      return new SuccessResult(Messages.ColorDeleted);
    }

    public  IDataResult< List<Colour>> GetAll()
    {
      return new SuccessDataResult<List<Colour>>(_colorDal.GetAll());
    }

    public IDataResult<Colour> GetColor(int colorId)
    {
      return new SuccessDataResult<Colour>(_colorDal.Get(c => c.Id == colorId));
    }

    [ValidationAspect(typeof(ColourValidator))]
    public IResult Update(Colour colour)
    {
      _colorDal.Update(colour);
      return new SuccessResult(Messages.ColorUpdated);
    }

    #region Rules

    private IResult CheckIfColorlExists(string colourName)
    {
      var result = _colorDal.GetAll(c=>c.Name == colourName).Count;
      if (result > 0)
      {
        return new ErrorResult(Messages.ColorAldreadyExists);
      }
      return new SuccessResult();
    }


    #endregion
  }
}
