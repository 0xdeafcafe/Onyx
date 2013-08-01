using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;

namespace Onyx.Cartographer.Areas.AdminCP.Controllers
{
    [RequireAdminAuthentication]
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