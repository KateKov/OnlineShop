
using OnlineShop.Infrastracture.Mappings;
using OnlineShop.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OnlineShop.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {

            // Configure Autofac

            AutofacConfig.SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

    }
}