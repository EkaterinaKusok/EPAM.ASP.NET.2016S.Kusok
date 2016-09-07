using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Day02.Task.ControllerFactory.Controllers;

namespace Day02.Task.ControllerFactory.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {


                case "Customer":
                    requestContext.RouteData.Values["controller"] = "User";
                    targetType = typeof(UserController);
                    break;
                case "User":
                    targetType = typeof(UserController);
                    break;
                case "Admin":
                    if (requestContext.HttpContext.Request.IsLocal)
                    {
                        targetType = typeof (AdminController);
                    }
                    break;
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "User";
                    targetType = typeof(UserController);
                    break;
            }
            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "Home":
                    return SessionStateBehavior.Disabled;
                default:
                    return SessionStateBehavior.Default;
            }
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}