using System;
using System.Web;
using Onyx.Cartographer.Models;
using System.Web.Mvc;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class AuthenticatedRedirect : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var dbContext = new DatabaseContext();

            // Get Session GUID
            var sessionGuid = HttpContext.Current.Request.Cookies["SessionGuid"];
            if (sessionGuid == null)
                return;

            var session = dbContext.Sessions.Find(Guid.Parse(sessionGuid.Value));
            if (session != null && session.Expires > DateTime.UtcNow)
                HttpContext.Current.Response.Redirect(_url);
        }

        private readonly string _url = "/Home/";

        public AuthenticatedRedirect(string url = "/Home/")
        {
            _url = url;
        }
    }
}
