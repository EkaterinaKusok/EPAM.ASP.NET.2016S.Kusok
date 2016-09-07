using System.Web.Mvc;
using Day02.Controller.Models;

namespace Day02.Controller.Controllers
{
    public class ProductController : System.Web.Mvc.Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("Result", new Result()
            {
                ControllerName = "Product",
                ActionName = "Index"
            });
        }

        public ActionResult List()
        {
            return View("Result", new Result()
            {
                ControllerName = "Product",
                ActionName = "List"
            });
        }
    }
}