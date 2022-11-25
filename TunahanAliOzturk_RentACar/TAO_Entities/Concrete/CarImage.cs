using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO_Entities.Concrete
{
  public partial class CarImage : IEntity
  {
    public int Id { get; set; }
    public int CarId { get; set; }
    public string? ImagePath { get; set; }
    public DateTime Date { get; set; }
  }
}
