using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day03.Task.Infrastructure;

namespace Day03.Task.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Repository = UserRepository.Instance;
        }

        public UserRepository Repository { get; }
    }
}