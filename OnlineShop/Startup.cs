﻿using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Identity;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(OnlineShop.Startup))]
namespace OnlineShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<OnlineShopContext>(OnlineShopContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            //app.UseFacebookAuthentication(
            //   appId: "592200494293334",
            //   appSecret: "b901da5d74ac2243289ee1c7ec8262a4");
        }
    }
}
