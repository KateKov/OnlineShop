using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;

namespace OnlineShop
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuthentication(IAppBuilder app)
        {
            // User a single instance of OnlineShopContext and AppUserManager per request
            app.CreatePerOwinContext(OnlineShopContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //Register of AppRoleManager
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            // Configure the application authentication with coockie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            
        }
    }
}