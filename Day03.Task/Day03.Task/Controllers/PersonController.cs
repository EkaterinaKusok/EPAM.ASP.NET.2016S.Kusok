﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day03.Task.Models;

namespace Day03.Task.Controllers
{
    public class PersonController : BaseController
    {
        //public PersonController() : base() { }

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

        //[ChildActionOnly]
        public ActionResult Footer(Side side)
        {
            return PartialView((object)side);
        }

        public ActionResult ChangeSide(User user)
        {
            this.Repository.ChangeSide(user);
            return RedirectToAction("Index", user.Id);
        }
    }
}