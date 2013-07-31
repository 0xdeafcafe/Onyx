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
            var userId = (int)(HttpContext.Current.Session["UserId"] ?? -1);

            if (userId != -1 && dbContext.Users.Find(userId) != null) return;

            HttpContext.Current.Response.RedirectToRoute("WelcomeRoute");
        }
    }
}
