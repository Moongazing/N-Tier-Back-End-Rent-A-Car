using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Entities.Concrete;



namespace TAO_Business.Abstract
{
  public interface IColourService
  {
    IDataResult<List<Colour>>GetAll();
    IDataResult<Colour> GetColor(int colorId);
    IResult Add(Colour colour);
    IResult Delete(Colour colour);
    IResult Update(Colour colour);
  }
}
