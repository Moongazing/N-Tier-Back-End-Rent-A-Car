using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Entities.Concrete;

namespace TAO_Business.ValidationRules.FluentValidation
{
  public class RentalValidator:AbstractValidator<Rental>
  {
    public RentalValidator()
    {
      #region NotEmptyRules
      RuleFor(r => r.CarId).NotEmpty();
      RuleFor(r=> r.CustomerId).NotEmpty();
      RuleFor(r=>r.RentDate).NotEmpty();
      #endregion


      //Geriye dönük işlem yaptırmama -- denenecek!
      RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Today);
    }
  }
}
