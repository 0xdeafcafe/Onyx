using System;
using System.Web;
using System.Web.Mvc;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class AuthenticatedRedirect : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Helpers.GetAuthenticatedUser() != null)
                HttpContext.Current.Response.Redirect(_url);
        }

        private readonly string _url = "/Home/";

        public AuthenticatedRedirect(string url = "/Home/")
        {
            _url = url;
        }
    }
}
