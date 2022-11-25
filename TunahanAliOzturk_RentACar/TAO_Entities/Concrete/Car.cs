﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO_Entities.Concrete
{
  public class Car:IEntity
  {
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public string Name { get; set; }
    public string ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }


  }
}
