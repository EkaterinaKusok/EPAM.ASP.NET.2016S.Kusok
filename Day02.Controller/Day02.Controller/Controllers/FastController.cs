using System.Web.Mvc;
using System.Web.SessionState;
using Day02.Controller.Models;

namespace Day02.Controller.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : System.Web.Mvc.Controller
    {
        // GET: Fast
        public ActionResult Index()
        {
            return View("Result", new Result()
            {
                ControllerName = "Fast",
                ActionName = "Index"
            });
        }
    }
}