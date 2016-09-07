using System.Web.Mvc;
using Day02.Task.Attributes.Infrastructure;

namespace Day02.Task.Attributes.Controllers
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