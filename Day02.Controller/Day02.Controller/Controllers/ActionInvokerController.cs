using System.Web.Mvc;
using Day02.Controller.Infrastructure;
using Day02.Controller.Models;

namespace Day02.Controller.Controllers
{
    public class ActionInvokerController : System.Web.Mvc.Controller
    {
        public ActionInvokerController()
        {
            this.ActionInvoker = new CustomActionInvoker();
        }

        public ActionResult Index()
        {
            return View("Result", new Result()
            {
                ControllerName = "ActionInvoker",
                ActionName = "Index"
            });
        }
    }
}