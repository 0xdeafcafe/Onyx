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
        public ActionResult Edit(int userId)
        {
            return View();
        }
	}
}