using System.Data;
using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Models;
using PagedList;

namespace Onyx.Cartographer.Areas.AdminCP.Controllers
{
    [RequireAdminAuthentication]
    public class RolesController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        //
        // GET: /AdminCP/Roles/
        public ActionResult Index(int? page)
        {
            return View(_dbContext.Roles.ToPagedList(_dbContext.Roles.Count(), page ?? 1, 25));
        }

        //
        // GET: /AdminCP/Roles/Add/
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /AdminCP/Roles/Add/
        [HttpPost]
        public ActionResult Add(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);

            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }

        // 
        // GET: /AdminCP/Roles/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var role = _dbContext.Roles.Find(id);

            if (role == null)
                return HttpNotFound();

            _dbContext.Entry(role).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }

        //
        // GET: /AdminCP/Roles/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var role = _dbContext.Roles.Find(id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        //
        // POST: /AdminCP/Roles/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            if (!ModelState.IsValid)
                return View(role);

            _dbContext.Entry(role).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }
    }
}