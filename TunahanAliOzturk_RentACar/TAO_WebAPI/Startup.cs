using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAO_Business.Abstract;
using TAO_Business.Concrete;
using TAO_Business.DependencyResolvers.Autofac;
using TAO_Core.DependencyResolvers;
using TAO_Core.Utilities.Extensions;
using TAO_Core.Utilities.IoC;
using TAO_Core.Utilities.Security.Encryption;
using TAO_Core.Utilities.Security.JWT;
using TAO_DataAccess.Abstract;
using TAO_DataAccess.Concrete.EntityFramework;

namespace TAO_WebAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
            options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidIssuer = tokenOptions.Issuer,
              ValidAudience = tokenOptions.Audience,
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
            };
          });
      services.AddDependencyResolvers(new ICoreModule[]
      {
        new CoreModule()
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseAuthentication();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
