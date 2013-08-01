using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Models;
using PagedList;

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
        // GET: /AdminCP/Users/Edit/1
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var user = _dbContext.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        //
        // POST: /AdminCP/Users/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User userModel)
        {
            return View(userModel);
        }
	}
}