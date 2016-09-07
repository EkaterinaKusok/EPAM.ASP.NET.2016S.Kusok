using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Day02.Task.ControllerFactory.Infrastructure;
using Day02.Task.ControllerFactory.Models;

namespace Day02.Task.ControllerFactory.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await this.Repository.Add(user);
            return RedirectToAction("Index");
        }
        
        public async Task<ActionResult> Remove(string id)
        {
            await this.Repository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}