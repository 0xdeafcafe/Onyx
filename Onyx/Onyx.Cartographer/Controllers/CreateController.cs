using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Onyx.Cartographer.Extensions;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Extensions.FlashMessages;
using Onyx.Cartographer.Models;
using Onyx.Cartographer.ViewModels.Project;
using System.Web;

namespace Onyx.Cartographer.Controllers
{
    [RequireAuthentication]
    public class CreateController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        //
        // GET: /Create/
        public ActionResult Index()
        {
            var user = Helpers.GetAuthenticatedUser();

            if (user != null)
            {
                var recentProjects =
                    _dbContext.Projects.Where(p => p.UserId == user.Id)
                        .GroupBy(proj => proj.UpdatedAt)
                        .Take(10).SelectMany(project => project).ToList();

                ViewData["RecentProjects"] = recentProjects;
            }

            return View();
        }

        //
        // POST: /Create/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateProject createProject, HttpPostedFileBase stfsUpload)
        {
            if (!ModelState.IsValid)
                return View();

            // Get the User
            var user = Helpers.GetAuthenticatedUser();
            if (user == null)
                return View();

            // Check Name is Unique
            if (_dbContext.Projects.Count(p =>
                p.Name.ToLower() == createProject.ProjectName.ToLower() && !p.IsDeleted) > 0)
            {
                ModelState.AddModelError("ProjectName", "You can't have 2 Projects with the same name.");
                return View();
            }

            // Create Project Entry
            var project = new Project
            {
                Name = createProject.ProjectName,
                Description = createProject.ProjectDescription,
                UserId = user.Id
            };
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return RedirectToAction("Edit", new { id = project.Id });
        }

        // 
        // GET: /Create/Edit/1-slug
        public ActionResult Edit(int? id)
        {
            var projectId = id;
            if (projectId == null)
                return RedirectToAction("Index").Error("You didn't specify a project.");

            var user = Helpers.GetAuthenticatedUser();
            if (user == null)
                return RedirectToAction("Index").Error("You must be signed in to edit projects.");

            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == projectId);
            if (project == null)
                return RedirectToAction("Index").Error("The specified project doesn't exist.");

            if (project.UserId != user.Id)
                return RedirectToAction("Index").Error("You can't edit projects you don't own.");

            ViewData["Project"] = project;

            return View();
        }
	}
}
