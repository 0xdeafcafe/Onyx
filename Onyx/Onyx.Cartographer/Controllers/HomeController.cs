using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;

namespace Onyx.Cartographer.Controllers
{
    [RequireAuthentication]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}