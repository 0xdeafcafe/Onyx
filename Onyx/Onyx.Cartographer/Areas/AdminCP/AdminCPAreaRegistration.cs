using System.Web.Mvc;

namespace Onyx.Cartographer.Areas.AdminCP
{
    public class AdminCPAreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "AdminCP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
		{
            context.MapRoute(
                "AdminCP",
                "AdminCP/{controller}/{action}/{id}",
                new { controller = "Hub", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "AdminCP_Pages",
                "AdminCP/{controller}/{action}/{page}",
                new { controller = "Hub", action = "Index", page = UrlParameter.Optional }
            );
        }
    }
}