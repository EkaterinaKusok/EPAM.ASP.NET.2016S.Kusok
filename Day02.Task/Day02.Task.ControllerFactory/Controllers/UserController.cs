using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Day02.Task.ControllerFactory.Models;

namespace Day02.Task.ControllerFactory.Controllers
{
    public class UserController : BaseController
    {
        [ActionName("Add-User")]
        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }
        [ActionName("Add-User")]
        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            //user.Id = "1";
            await this.Repository.Add(user);
            return RedirectToAction("User-List");
        }
        
        [ActionName("User-List")]
        [HttpGet]
        public ActionResult List()
        {
            var list = this.Repository.GetAll();
            return View("List", list);
        }

        [ActionName("User-List")]
        [HttpPost]
        public JsonResult ListPost()
        {
            return Json(this.Repository.GetAll());
        }

    }
}