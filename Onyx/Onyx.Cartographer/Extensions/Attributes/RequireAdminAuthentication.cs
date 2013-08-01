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
            var userId = (int)(HttpContext.Current.Session["UserId"] ?? -1);
            var user = dbContext.Users.Find(userId);

            if (user == null || !user.IsAdmin)
                HttpContext.Current.Response.Redirect(_url);
        }

        private readonly string _url = "/Home/";

        public RequireAdminAuthentication(string url = "/Home/")
        {
            _url = url;
        }
    }
}
