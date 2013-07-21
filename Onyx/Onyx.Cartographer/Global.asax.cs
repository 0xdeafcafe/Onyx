using Onyx.Cartographer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Onyx.Cartographer
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
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
			Exception lastError = Server.GetLastError();
			Server.ClearError();

			int statusCode = 0;

			if (lastError.GetType() == typeof(HttpException))
			{
				statusCode = ((HttpException)lastError).GetHttpCode();
			}
			else
			{
				// Not an HTTP related error so this is a problem in our code, set status to
				// 500 (internal server error)
				statusCode = 500;
			}

			RouteData routeData = new RouteData();
			routeData.Values.Add("controller", "Error");
			routeData.Values.Add("action", "Index");
			routeData.Values.Add("statusCode", statusCode);
			routeData.Values.Add("exception", lastError);

			IController controller = new ErrorController();

			RequestContext requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);

			controller.Execute(requestContext);
#endif
		}
    }
}
