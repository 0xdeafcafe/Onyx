using System;
using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Extensions.Cryptography;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        //
        // GET: /Account/Signin/
        [AuthenticatedRedirect]
        public ActionResult Signin()
        {
            return View();
        }

		//
        // POST: /Account/Signin/
        [AuthenticatedRedirect]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(User userModel)
		{
            if (!ModelState.IsValid) return View();

            var user = _dbContext.Users.SingleOrDefault(u => u.Username == userModel.Username);

            if (user == null)
                ModelState.AddModelError("Username", "Invalid Username");
            else
            {
                var hashedPassword = Sha1Crypto.ComputeHashToString(userModel.Password);
                if (String.Equals(user.Password, hashedPassword, StringComparison.InvariantCultureIgnoreCase))
                {
                    Session["UserId"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Invalid Password");
            }
            return View();
		}

        //
        // GET: /Account/Signout/
        [RequireAuthentication]
        public ActionResult Signout()
        {
            Session["UserId"] = null;
            return RedirectToAction("Index", "Welcome");
        }
	}
}
