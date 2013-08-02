using System;
using System.Web.Mvc;
using System.Web;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class RequireAuthentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Helpers.GetAuthenticatedUser() == null)
                HttpContext.Current.Response.RedirectToRoute("WelcomeRoute");
        }
    }
}
