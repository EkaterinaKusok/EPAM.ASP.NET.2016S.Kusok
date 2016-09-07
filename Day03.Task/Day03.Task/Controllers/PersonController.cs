using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day03.Task.Models;

namespace Day03.Task.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController() : base() { }

        public ActionResult Index(string id)
        {
            User user;
            if (id == string.Empty)
            {
                user = this.Repository.GetAll().FirstOrDefault();
            }
            else
            {
                user = this.Repository.GetById(id);
            }
            return View(user);
        }

        public ActionResult ChangeSide(User user)
        {
            if (user.Side == Side.white)
            {
                this.Repository.ChangeSide(user, Side.black);
            }
            else
            {
                this.Repository.ChangeSide(user,Side.white);
            }
            return RedirectToAction("Index", user.Id);
        }
    }
}