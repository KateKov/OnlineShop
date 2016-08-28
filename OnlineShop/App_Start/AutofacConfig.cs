using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using OnlineShop.DAL.EF;
using OnlineShop.DAL.Entities;
using System.Data.Entity;
using OnlineShop.DAL.Infrastracture;
using OnlineShop.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.DAL.Identity;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace OnlineShop.Web.App_Start
{
    public class AutofacConfig
    {
       
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // EF OnlineShopContext
            builder.RegisterType<OnlineShopContext>().AsSelf().Instance‌​PerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.Register<UserStore<User>>(c => new UserStore<User>(new OnlineShopContext())).AsImplementedInterfaces().Instanc‌​ePerRequest();
            builder.Register<IdentityFactoryOptions<AppUserManager>>(c => new IdentityFactoryOptions<AppUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("OnlineShop")
            });
            builder.RegisterType<AppUserManager>().AsSelf().Inst‌​ancePerRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}