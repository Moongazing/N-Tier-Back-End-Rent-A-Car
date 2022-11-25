using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO_Entities.Concrete
{
  public class Rental:IEntity
  {
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
  }
}
