using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Day02.Controller.Infrastructure;

namespace Day02.Controller
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // заменить фабрику контроллеров на свою
            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            // добывить свой активатор контроллеров
            //ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));
        }
    }
}
