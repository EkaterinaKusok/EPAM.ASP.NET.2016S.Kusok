using System.Threading.Tasks;
using System.Web.Mvc;
using Day02.Controller.Models;

namespace Day02.Controller.Controllers
{
    public class RemoteDataController : System.Web.Mvc.Controller
    {
        public async Task<ActionResult> Data()
        {
            var data = await Task<string>.Factory.StartNew(() => new RemoteService().GetRemoteData());
            return View((object) data);
        }

        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            var data = await new RemoteService().GetRemoteDataAsync();
            return View("Data", (object)data);
        }
    }
}