using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Nitrogen.Content.UserGenerated.Halo4;
using Onyx.Cartographer.Extensions;
using Onyx.Cartographer.Extensions.Attributes;
using Onyx.Cartographer.Extensions.FlashMessages;
using Onyx.Cartographer.Models;
using Onyx.Cartographer.ViewModels.Project;
using System.Web;
using VelocityNet.Stfs;
using Onyx.Cartographer.Extensions.Wrappers;

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

            // Do file validation stuff
            GameType gametype;
            if (stfsUpload == null)
            {
                ModelState.AddModelError("File", "You must select a Halo 4 Gametype to create a project.");
                return View();
            }
            else
            {
                var outputPath = Path.GetTempFileName();
                var variantExtrated = Path.GetTempFileName();
                System.IO.File.WriteAllBytes(outputPath, VariousFunctions.StreamToByteArray(stfsUpload.InputStream));
                try
                {
                    var stfsParsed = new StfsPackage(outputPath);

                    // Validate contains variant
                    if (!stfsParsed.FileExists("variant"))
                        throw new Exception();

                    // Extract variant
                    stfsParsed.ExtractFile("variant", variantExtrated);

                    gametype = GameType.Load(variantExtrated);

                    // TODO: seralize gametype data
                    var seralizedData = "";

                    // Write data to Database
                    var project = new Project
                    {
                        Name = createProject.ProjectName,
                        Description = createProject.ProjectDescription,
                        UserId = user.Id
                    };

                    // Write data to the S3 Bucket
                    try
                    {
                        var s3 = new S3Storage();
                        s3.WriteObject(VariousFunctions.StreamToByteArray(stfsUpload.InputStream),
                            S3Storage.StorageLocations.Stfs, project.StfsId);
                        s3.WriteObject(seralizedData, 
                            S3Storage.StorageLocations.Solution, project.SolutionId);
                    }
                    catch
                    {
                        return RedirectToAction("Index").Error("There was an unknown error trying to create the project.");
                    }

                    // Save project to database
                    _dbContext.Projects.Add(project);
                    _dbContext.SaveChanges();

                    // Delete files now we done, yo
                    System.IO.File.Delete(outputPath);
                    System.IO.File.Delete(variantExtrated);
                }
                catch
                {
                    // Uh Oh, NSA - get the fuck out of here, and delete all the evidence.
                    System.IO.File.Delete(outputPath);
                    System.IO.File.Delete(variantExtrated);

                    ModelState.AddModelError("File", "Invalid Halo 4 Gametype.");
                    return View();
                }
            }

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
