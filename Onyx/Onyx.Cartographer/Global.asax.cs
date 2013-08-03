using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Onyx.Cartographer
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		protected void Application_Error(object sender, EventArgs e)
		{
#if !DEBUG
			var lastError = Server.GetLastError();
			Server.ClearError();

		    var statusCode = lastError.GetType() == typeof(HttpException) ? ((HttpException)lastError).GetHttpCode() : 500;

			var routeData = new RouteData();
			routeData.Values.Add("controller", "Error");
			routeData.Values.Add("action", "Index");
			routeData.Values.Add("statusCode", statusCode);
			routeData.Values.Add("exception", lastError);

			IController controller = new Controllers.ErrorController();

			var requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);

			controller.Execute(requestContext);
#endif
		}
    }
}
