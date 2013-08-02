using System.Data;
using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
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

            var user = _dbContext.Users.Find(userModel.Id);

            return RedirectToAction("Index", "Users");
        }
	}
}
