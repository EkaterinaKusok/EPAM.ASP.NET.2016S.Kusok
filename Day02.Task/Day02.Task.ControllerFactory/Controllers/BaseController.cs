using System.Web.Mvc;
using Day02.Task.ControllerFactory.Infrastructure;

namespace Day02.Task.ControllerFactory.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Repository = UserRepository.Instance;
        }

        public UserRepository Repository { get; }

        protected override void HandleUnknownAction(string actionName)
        {
            this.View("Error404").ExecuteResult(this.ControllerContext);
        }
    }
}