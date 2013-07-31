using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;

namespace Onyx.Cartographer.Controllers
{
    [RequireAuthentication]
    public class CreateController : Controller
    {
        //
        // GET: /Create/
        public ActionResult Index()
        {
            return View();
        }
	}
}