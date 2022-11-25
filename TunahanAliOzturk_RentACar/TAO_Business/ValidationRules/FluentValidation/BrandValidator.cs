using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Entities.Concrete;

namespace TAO_Business.ValidationRules.FluentValidation
{
  public class BrandValidator:AbstractValidator<Brand>
  {
    public BrandValidator()
    {
      #region NotEmptyRules
      RuleFor(b => b.Name).NotEmpty();
      #endregion

      #region LengthRules
      RuleFor(b => b.Name).MinimumLength(2).MaximumLength(20);
      #endregion
    }
  }
}
