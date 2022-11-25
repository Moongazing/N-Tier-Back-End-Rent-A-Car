using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core;

namespace TAO_Entities.DTOs
{
  public class RentalDetailDto:IDto
  {
    public int RentalId { get; set; }
    public int CarId { get; set; }
    public string CarName { get; set; }
    public string ColourName { get; set; }
    public string BrandName { get; set; }
    public int CustomerId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
  }
}
