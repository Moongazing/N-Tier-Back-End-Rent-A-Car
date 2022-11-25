using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Entities.Concrete;

namespace TAO_Business.ValidationRules.FluentValidation
{
  public class CarValidator:AbstractValidator<Car>
  {
    public CarValidator()
    {
      #region NotEmptyRules
      RuleFor(c => c.Name).NotEmpty();
      RuleFor(c => c.DailyPrice).NotEmpty();
      RuleFor(c => c.BrandId).NotEmpty();
      RuleFor(c => c.ColorId).NotEmpty();
      RuleFor(c => c.ModelYear).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
      #endregion

      #region LengthRules

      RuleFor(c => c.Name).MinimumLength(2).MaximumLength(18);
      RuleFor(c => c.Description).MinimumLength(2).MaximumLength(18);
      RuleFor(c=>c.ModelYear).MinimumLength(4).MaximumLength(4);

      RuleFor(c => c.DailyPrice).GreaterThan(100);

      #endregion
    }
  }
}
