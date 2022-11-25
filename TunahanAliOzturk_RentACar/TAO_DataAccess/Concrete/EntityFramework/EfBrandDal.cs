using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TAO_Core.DataAccess.EntityFramework;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class EfBrandDal : EfEntityRepositoryBase<Brand,TAO_RentACarContext>,IBrandDal
  {
  }
  
}
