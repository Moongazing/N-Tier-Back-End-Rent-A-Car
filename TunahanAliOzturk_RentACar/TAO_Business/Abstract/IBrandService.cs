using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Entities.Concrete;

namespace TAO_Business.Abstract
{
  public interface IBrandService
  {
    IDataResult<List<Brand>> GetAll();
    IDataResult<Brand>GetById(int brandId);
    IResult Add(Brand brand);
    IResult Delete(Brand brand);
    IResult Update(Brand brand);
  }
}

