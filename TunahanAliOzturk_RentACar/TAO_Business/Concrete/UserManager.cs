using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using TAO_Business.Abstract;
using TAO_Business.Constants;
using TAO_Business.ValidationRules.FluentValidation;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Entities.Concrete;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;

namespace TAO_Business.Concrete
{

  public class UserManager : IUserService
  {
    IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
      _userDal = userDal;
    }
    [ValidationAspect(typeof(UserValidator))]

    public IResult Add(User user)
    {
      IResult result = BusinessRules.Run(
        CheckIfEmailExists(user.Email));
      if (result != null)
      {
        return result;
      }

      _userDal.Add(user);
      return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User user)
    {
      _userDal.Delete(user);
      return new SuccessResult(Messages.UserDeleted);
    }

    public IDataResult<List<User>> GetAll()
    {
      return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public User GetByMail(string email)
    {
      return _userDal.Get(u => u.Email == email);
    }

    public List<OperationClaim> GetClaims(User user)
    {
      return _userDal.GetClaims(user);
    }

    public IDataResult<User> GetUser(int userId)
    {
      return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
    }

    [ValidationAspect(typeof(UserValidator))]
    public IResult Update(User user)
    {
      _userDal.Add(user);
      return new SuccessResult(Messages.UserUpdated);
    }


    #region Rules
    private IResult CheckIfEmailExists(string email)
    {
      var result = _userDal.GetAll(u => u.Email == email).Count;
      if (result > 0)
      {
        return new ErrorResult(Messages.EmailAldreadyExists);
      }
      return new SuccessResult();
    }
    #endregion
  }
}
