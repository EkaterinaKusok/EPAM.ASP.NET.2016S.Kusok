using System.Web.Mvc;
using Day02.Controller.Infrastructure;
using Day02.Controller.Models;

namespace Day02.Controller.Controllers
{
    public class CustomerController : System.Web.Mvc.Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("Result", new Result()
            {
                ControllerName = "Customer",
                ActionName = "Index"
            });
        }

        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result()
            {
                ControllerName = "Customer",
                ActionName = "LocalIndex"
            });
        }

        //[ActionName("Enumerate")]
        public ActionResult List()
        {
            return View("Result", new Result()
            {
                ControllerName = "Customer",
                ActionName = "List"
            });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(string.Format("You requested the {0} action", actionName));
        }
    }
}