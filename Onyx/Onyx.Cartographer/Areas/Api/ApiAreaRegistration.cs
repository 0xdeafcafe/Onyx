using System.Web.Http;
using System.Web.Mvc;

namespace Onyx.Cartographer.Areas.Api
{
    public class ApiAreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
		{
            context.Routes.MapHttpRoute(
                "ApiDefault",
                "api/{controller}",
                new { }
            );

            context.Routes.MapHttpRoute(
                "ApiWithQuery",
                "api/{controller}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}
