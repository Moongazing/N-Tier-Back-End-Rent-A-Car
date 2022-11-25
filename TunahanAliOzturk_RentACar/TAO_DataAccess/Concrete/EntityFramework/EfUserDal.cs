using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.DataAccess.EntityFramework;
using TAO_Core.Entities.Concrete;
using TAO_DataAccess.Abstract;
using TAO_Entities.Concrete;
using System.Linq;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class EfUserDal : EfEntityRepositoryBase<User, TAO_RentACarContext>, IUserDal
  {
    public List<OperationClaim> GetClaims(User user)
    {
      using (var context = new TAO_RentACarContext())
      {
        var result = from operationClaim in context.OperationClaims
                     join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                     where userOperationClaim.UserId == user.Id
                     select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
        return result.ToList();

      }
    }

  }
}
