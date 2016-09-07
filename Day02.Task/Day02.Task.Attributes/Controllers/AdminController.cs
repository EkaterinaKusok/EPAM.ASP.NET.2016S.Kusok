using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Day02.Task.Attributes.Infrastructure;
using Day02.Task.Attributes.Models;

namespace Day02.Task.Attributes.Controllers
{
    public class AdminController : BaseController
    {
        [Local]
        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
        }

        [Local]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Local]
        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await this.Repository.Add(user);
            return RedirectToAction("Index");
        }

        [Local]
        public async Task<ActionResult> Remove(string id)
        {
            await this.Repository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}