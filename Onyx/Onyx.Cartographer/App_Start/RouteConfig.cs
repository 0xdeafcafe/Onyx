using System.Web.Mvc;
using System.Web.Routing;

namespace Onyx.Cartographer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Onyx.Cartographer.Controllers" });

            routes.MapRoute(
                "WelcomeRoute",
                "Welcome");
        }
    }
}
