using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities.Concrete;
using TAO_Entities.Concrete;

namespace TAO_Business.ValidationRules.FluentValidation
{
  public class UserValidator:AbstractValidator<User>
  {
    public UserValidator()
    {
      #region NotEmptyRules

      RuleFor(u => u.FirstName).NotEmpty();
      RuleFor(u => u.LastName).NotEmpty();
      RuleFor(u => u.Email).NotEmpty();
     // RuleFor(u => u.Password).NotEmpty();

      #endregion

      #region ContainRules
      RuleFor(u => u.Email).ToString().Contains(".com");
      RuleFor(u => u.Email).ToString().Contains("@");
      #endregion

      #region LengthRules
      RuleFor(u => u.FirstName).MinimumLength(2).MaximumLength(20);
      RuleFor(u => u.LastName).MinimumLength(2).MaximumLength(20);
      RuleFor(u => u.Email).MinimumLength(2).MaximumLength(20);
      //RuleFor(u => u.Password).MinimumLength(2).MaximumLength(20);
      #endregion
    }
  }
}
