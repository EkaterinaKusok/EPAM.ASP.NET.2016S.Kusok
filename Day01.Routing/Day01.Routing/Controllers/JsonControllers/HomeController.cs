using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day01.Routing.Controllers.JsonControllers
{
    public class HomeController : Controller
    {
        public JsonResult Index(string comment, string id = "no id")
        {
            return Json(new List<string>() { id, comment}, JsonRequestBehavior.AllowGet);
        }
    }
}