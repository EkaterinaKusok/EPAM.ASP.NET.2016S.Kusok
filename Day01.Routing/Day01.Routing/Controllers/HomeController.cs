using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day01.Routing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id = "no id")
        {
            //ViewBag.Id = RouteData.Values["id"];
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Static(string id = "no id")
        {
            ViewBag.Id = id;
            return View("Index");
        }

        public ActionResult Static1(string id = "no id")
        {
            ViewBag.Id = id;
            return View("Index");
        }
    }
}