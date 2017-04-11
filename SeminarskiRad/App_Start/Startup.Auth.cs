using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using SeminarskiRad.Models;
using SeminarskiRad.Models.IdentityModels;
using SeminarskiRad.Services;
using IdentityDbContext = SeminarskiRad.Models.Context.IdentityDbContext;

namespace SeminarskiRad
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(IdentityDbContext.Create);
            app.CreatePerOwinContext<SeminarEmployeeManager>(SeminarEmployeeManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<SeminarEmployeeManager, SeminarEmployee, int>(
                        TimeSpan.FromMinutes(30),
                        (manager, user) => user.GenerateUserIdentityAsync(manager), identity => int.Parse(identity.GetUserId()))
                }
            });
        }
    }
}