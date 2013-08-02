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
    }
}