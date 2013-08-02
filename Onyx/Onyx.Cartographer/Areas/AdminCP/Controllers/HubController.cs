using System.Linq;
using System.Web.Mvc;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.Areas.AdminCP.Controllers
{
    [RequireAdminAuthentication]
    public class HubController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        //
        // GET: /AdminCP/Hub/
        public ActionResult Index()
        {
            ViewData["TotalUsersCount"] = _dbContext.Users.Count();
            ViewData["TotalPrimaryUsersCount"] = _dbContext.Users.Count(u => u.Role.Identifier == Roles.PrimaryUser);
            ViewData["TotalModeratorUsersCount"] = _dbContext.Users.Count(u => u.Role.Identifier == Roles.Moderator);
            ViewData["TotalAdministratorUsersCount"] = _dbContext.Users.Count(u => u.Role.Identifier == Roles.Administrator);

            return View();
        }
	}
}