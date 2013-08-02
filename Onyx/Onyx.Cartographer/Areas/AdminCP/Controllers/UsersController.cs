using System.Data;
using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Extensions.Cryptography;
using Onyx.Cartographer.Models;
using PagedList;
using Onyx.Cartographer.ViewModels.User;

namespace Onyx.Cartographer.Areas.AdminCP.Controllers
{
    [RequireAdminAuthentication]
    public class UsersController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        //
        // GET: /AdminCP/Users/
        public ActionResult Index(int? page)
        {
            return View(_dbContext.Users.ToPagedList(_dbContext.Users.Count(), page ?? 1, 25));
        }

        //
        // GET: /AdminCP/Users/Add/
        public ActionResult Add()
        {
            ViewData["Roles"] = _dbContext.Roles;
            return View();
        }

        //
        // POST: /AdminCP/Users/Add/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserAdminEdit userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);

            // Validate Password
            if (userModel.Password == "")
            {
                ModelState.AddModelError("Password", "You must enter a password.");
                return View(userModel);
            }
            // Move VM into the User Model Object
            var user = new User
            {
                Username = userModel.Username,
                Password = Pbkdf2Crypto.ComputeHash(userModel.Password),
                Email = userModel.Email,
                RoleId = userModel.RoleId,
                RegisterDate = userModel.RegisterDate,
                LastSigninDate = userModel.LastSigninDate
            };

            // Save to DB
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        // 
        // GET: /AdminCP/Users/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();
            var user = _dbContext.Users.Find(id);
            if (user == null) return HttpNotFound();

            _dbContext.Entry(user).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        //
        // GET: /AdminCP/Users/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var user = _dbContext.Users.Find(id);
            if (user == null) return HttpNotFound();

            ViewData["Roles"] = _dbContext.Roles;

            return View(new UserAdminEdit(user));
        }

        //
        // POST: /AdminCP/Users/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAdminEdit userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);

            // Get User
            var user = _dbContext.Users.Find(userModel.Id);

            // Hash new password, if there isn't one, use old pass
            userModel.Password = userModel.Password == "" ? user.Password : Pbkdf2Crypto.ComputeHash(userModel.Password);

            // Move VM into the User Model Object
            user.Username = userModel.Username;
            user.Password = userModel.Password;
            user.Email = userModel.Email;
            user.RoleId = userModel.RoleId;
            user.RegisterDate = userModel.RegisterDate;
            user.LastSigninDate = userModel.LastSigninDate;

            // Save to DB
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
	}
}
