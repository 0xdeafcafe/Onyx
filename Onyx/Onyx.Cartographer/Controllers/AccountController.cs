using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Extensions.Cryptography;
using Onyx.Cartographer.Models;
using Onyx.Cartographer.ViewModels.User;

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
        public ActionResult Signin(SignIn userModel)
		{
            if (!ModelState.IsValid) return View();

            var user = _dbContext.Users.SingleOrDefault(u => u.Username == userModel.Username);

            if (user == null)
                ModelState.AddModelError("Username", "Invalid Username");
            else
            {
                var hashedPassword = Pbkdf2Crypto.ComputeHash(userModel.Password);
                if (String.Equals(user.Password, hashedPassword, StringComparison.InvariantCultureIgnoreCase))
                {
                    // Create Session
                    var session = new Session { UserId = user.Id };

                    // Cookies
                    var cookie = new HttpCookie("SessionGuid", session.SessionId.ToString())
                    {
                        Expires = DateTime.UtcNow.AddDays(2)
                    };

                    // are we crying? ;_;
                    if (userModel.RememberMe)
                        cookie.Expires = session.Expires =
                            DateTime.UtcNow.AddYears(69);

                    // Set dat cookie
                    Response.SetCookie(cookie);

                    // Database Stuff
                    _dbContext.Sessions.Add(session);
                    _dbContext.SaveChanges();

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
            Session.Remove("UserId");
            return RedirectToAction("Index", "Welcome");
        }
	}
}
