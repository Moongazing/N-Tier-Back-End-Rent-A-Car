using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Business.Constants;
using TAO_Core.Utilities.Interceptors;
using TAO_Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using TAO_Core.Utilities.Extensions;

namespace TAO_Business.BussinesAspects.Autofac
{
  public class SecuredOperation : MethodInterception
  {
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor;

    public SecuredOperation(string roles)
    {
      _roles = roles.Split(',');
      _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

    }

    protected override void OnBefore(IInvocation invocation)
    {
      var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
      foreach (var role in _roles)
      {
        if (roleClaims.Contains(role))
        {
          return;
        }
      }
      throw new Exception(Messages.AuthorizationDenied);
    }
  }
}
