using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO_Entities.Concrete
{
  public class Colour:IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
