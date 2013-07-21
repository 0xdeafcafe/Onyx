using Onyx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onyx.Domain.Controllers
{
    public class HomeController : Controller
    {
		private readonly DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Onyx Domain";
            return View();
        }
    }
}
