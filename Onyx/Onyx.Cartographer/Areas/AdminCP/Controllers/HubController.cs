using System.Web.Mvc;

namespace Onyx.Cartographer.Areas.AdminCP.Controllers
{
    public class HubController : Controller
    {
        //
        // GET: /AdminCP/Hub/
        public ActionResult Index()
        {
            return View();
        }
	}
}