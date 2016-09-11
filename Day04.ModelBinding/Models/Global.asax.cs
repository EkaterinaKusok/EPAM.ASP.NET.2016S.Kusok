using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Models.Infrastructure;
using Models.Models;

namespace Models
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ValueProviderFactories.Factories.Clear();
            ValueProviderFactories.Factories.Add(new CustomValueProviderFactory());
            ModelBinders.Binders.Add(typeof(Person), new PersonBinder());

            //ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());
            //ModelBinders.Binders.Add(typeof(Address), new AddressBinder());
        }
    }
}
