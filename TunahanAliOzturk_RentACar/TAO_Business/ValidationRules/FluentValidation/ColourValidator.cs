using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Entities.Concrete;

namespace TAO_Business.ValidationRules.FluentValidation
{
  public class ColourValidator:AbstractValidator<Colour>

  {
    public ColourValidator()
    {
      #region NotEmptyRules
      RuleFor(c => c.Name).NotEmpty();
      #endregion

      #region LengthRules

      RuleFor(c => c.Name).MinimumLength(2).MaximumLength(15);

      #endregion
    }
  }
}
