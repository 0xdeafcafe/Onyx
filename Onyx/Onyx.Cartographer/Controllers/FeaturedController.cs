using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;

namespace Onyx.Cartographer.Controllers
{
    [RequireAuthentication]
    public class FeaturedController : Controller
    {
        //
        // GET: /Featured/
        public ActionResult Index()
        {
            return View();
        }
	}
}