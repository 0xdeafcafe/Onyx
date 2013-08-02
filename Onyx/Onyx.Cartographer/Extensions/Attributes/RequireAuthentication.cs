using System;
using System.Web.Mvc;
using Onyx.Cartographer.Models;
using System.Web;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class RequireAuthentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var dbContext = new DatabaseContext();

            // Get Session GUID
            var sessionGuid = HttpContext.Current.Request.Cookies["SessionGuid"];
            if (sessionGuid == null)
            {
                HttpContext.Current.Response.RedirectToRoute("WelcomeRoute");
                return;
            }

            var session = dbContext.Sessions.Find(Guid.Parse(sessionGuid.Value));
            if (session != null && session.Expires > DateTime.UtcNow) return;
            HttpContext.Current.Response.RedirectToRoute("WelcomeRoute");
        }
    }
}
