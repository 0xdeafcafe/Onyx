using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;

namespace Onyx.Cartographer.Controllers
{
    [RequireAuthentication]
    public class AboutController : Controller
    {
        //
        // GET: /About/
        public ActionResult Index()
        {
            return View();
        }
	}
}