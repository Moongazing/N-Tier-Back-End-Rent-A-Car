using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TAO_Core.DataAccess.EntityFramework;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;
using TAO_Entities.DTOs;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class EfCarDal : EfEntityRepositoryBase<Car, TAO_RentACarContext>, ICarDal
  {
    public List<CarDetailDto> GetCarDetails()
    {
      using (TAO_RentACarContext context = new TAO_RentACarContext())
      {
        var result = from c in context.Cars
                     join b in context.Brands on c.BrandId equals b.Id
                     join o in context.Colors on c.ColorId equals o.Id
                     select new CarDetailDto
                     {
                       CarId = c.Id,
                       CarName = c.Name,
                       BrandName = b.Name,
                       Colour = o.Name,
                       DailyPrice = c.DailyPrice,
                       ModelYear = c.ModelYear,
                       Description = c.Description
                     };
        return result.ToList();
      }
    }
  }
}
