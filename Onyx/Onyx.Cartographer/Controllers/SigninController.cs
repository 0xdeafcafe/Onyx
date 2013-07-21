using Onyx.Cartographer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
		public ActionResult Index(SigninModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Username == "" && model.Password == "")
				{
					FormsAuthentication.SetAuthCookie(model.Username, false);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid Username of Password.");
				}
			}

			return View();
		}
	}
}
