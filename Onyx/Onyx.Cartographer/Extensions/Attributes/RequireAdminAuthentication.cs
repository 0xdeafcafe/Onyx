using System;
using System.Web;
using Onyx.Cartographer.Models;
using System.Web.Mvc;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class RequireAdminAuthentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var dbContext = new DatabaseContext();

            // Get Session GUID
            var sessionGuid = HttpContext.Current.Request.Cookies["SessionGuid"];
            if (sessionGuid == null)
            {
                HttpContext.Current.Response.Redirect(_url);
                return;
            }

            var session = dbContext.Sessions.Find(Guid.Parse(sessionGuid.Value));
            if (session == null || session.Expires < DateTime.UtcNow)
            {
                HttpContext.Current.Response.Redirect(_url);
                return;
            }

            if (session.User.Role.Identifier != Models.Roles.Administrator)
                HttpContext.Current.Response.Redirect(_url);
        }

        private readonly string _url = "/Home/";

        public RequireAdminAuthentication(string url = "/Home/")
        {
            _url = url;
        }
    }
}
