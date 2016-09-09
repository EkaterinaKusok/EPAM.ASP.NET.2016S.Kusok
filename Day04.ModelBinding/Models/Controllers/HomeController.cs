using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Data;
using Models.Models;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IPersonRepo _repo;

	    public HomeController(IPersonRepo personRepo)
	    {
		    _repo = personRepo;
	    }

        public ActionResult Index(int id = 1)
        {
	        var person = _repo.GetAll().First(p => p.PersonId == id);
			return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress")] Address summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult Address(IList<Address> addresses)
        {
            addresses = addresses ?? new List<Address>();
            return View(addresses);
        }

        //public ActionResult Address(FormCollection formData)
        //{
        //    IList<Address> addresses = new List<Address>();
        //    //UpdateModel(addresses, new FormValueProvider(ControllerContext));
        //    if (TryUpdateModel(addresses, formData))
        //    {
        //        //normal
        //        return View(addresses);
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Во время редактирования возникли ошибки";
        //        return RedirectToAction("Address");
        //    }
        //}
    }
}