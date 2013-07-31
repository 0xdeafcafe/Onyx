using System.Web.Mvc;

namespace Onyx.Cartographer.Controllers
{
    public class SigninController : Controller
    {
        //
		// GET: /Signin/
        public ActionResult Index()
        {
            return View();
        }

		//
		// POST: /Signin/
		[HttpPost]
		public ActionResult Index(string data)
		{
			
			return View();
		}
	}
}
