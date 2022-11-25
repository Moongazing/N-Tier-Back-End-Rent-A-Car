using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core;
using TAO_Core.Entities;

namespace TAO_Entities.DTOs
{
  public class CarDetailDto:IDto
  {
    public int CarId { get; set; }
    public string CarName { get; set; }
    public string BrandName { get; set; }
    public string Colour { get; set; }
    public string ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }


  }
}
