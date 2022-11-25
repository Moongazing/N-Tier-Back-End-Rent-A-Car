using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.DataAccess.EntityFramework;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;
using TAO_Entities.DTOs;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class EfRentalDal : EfEntityRepositoryBase<Rental, TAO_RentACarContext>, IRentalDal
  {
    //public List<RentalDetailDto> GetRentalDetails()
    //{
    //  using (TAO_RentACarContext context = new TAO_RentACarContext())
    //  {
    //    var result = from r in context.Rentals
    //                 join c in context.Cars on c.Id equals r.CarId
    //                 join b in context.Brands on b.Id equals c.BrandId
    //                 join o in context.Colors on o.Id equals c.ColorsId
    //                 join u in context.Customers on u.Id equals r.CustomerId
    //                 select new RentalDetailDto
    //                 {

    //                 };



    //    return result.ToList();
    //  }
    }
  }

