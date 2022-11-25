using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.DataAccess.EntityFramework;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class EfCarImageDal : EfEntityRepositoryBase<CarImage, TAO_RentACarContext>, ICarImageDal
  {

  }
}
