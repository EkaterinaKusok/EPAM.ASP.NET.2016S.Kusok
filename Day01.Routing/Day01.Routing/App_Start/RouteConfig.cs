using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Day01.Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Static",
                url: "Home/Static/{id}",
                defaults: new { controller = "Home", action = "Static", id = UrlParameter.Optional},
                namespaces: new string[] { "Day01.Routing.Controllers" }
            );

            routes.MapRoute(
                name: "Constrains",
                url: "{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional},
                constraints: new { controller = "^H.*", action = "^S.*" },
                namespaces: new string[] { "Day01.Routing.Controllers" }
            );

            //will be error
            //routes.MapRoute( 
            //    name: "Namespase priority",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "NamespacePriority1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new { controller = "^H.*", action = "^I.*", id = new AlphaRouteConstraint() },
                namespaces: new string[] { "Day01.Routing.Controllers.JsonControllers" }
            );

            routes.MapRoute(
                name: "NamespacePriority2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                constraints: new { controller = "^H.*", action = "^I.*" },
                namespaces: new string[] { "Day01.Routing.Controllers" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "Index"},
                namespaces: new string[] { "Day01.Routing.Controllers" }
            );
        }
    }
}
