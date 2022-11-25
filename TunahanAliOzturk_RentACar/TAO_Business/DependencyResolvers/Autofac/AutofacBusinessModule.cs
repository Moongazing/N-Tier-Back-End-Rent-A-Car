using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Business.Abstract;
using TAO_Business.Concrete;
using TAO_Core.Utilities.Helpers.FileHelper;
using TAO_Core.Utilities.Interceptors;
using TAO_Core.Utilities.Security.JWT;
using TAO_DataAccess.Abstract;
using TAO_DataAccess.Concrete.EntityFramework;

namespace TAO_Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule:Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      /* Car */
      builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
      builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

      /* Brand */
      builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
      builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

      /* User */
      builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
      builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

      /* Rental */
      builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
      builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

      /* Colour */
      builder.RegisterType<ColourManager>().As<IColourService>().SingleInstance();
      builder.RegisterType<EfColourDal>().As<IColourDal>().SingleInstance();


      builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
      builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

      builder.RegisterType<AuthManager>().As<IAuthService>();
      builder.RegisterType<JwtHelper>().As<ITokenHelper>();

     //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

      builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();


      var assembly = System.Reflection.Assembly.GetExecutingAssembly();
      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                 Selector = new AspectInterceptorSelector()
               }).SingleInstance();


    }
  }
}
