using System;
using System.Web;
using System.Web.Mvc;

namespace Onyx.Cartographer.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class RequireAdminAuthentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = Helpers.GetAuthenticatedUser();

            if (user == null)
                HttpContext.Current.Response.Redirect(_url);
            else if (user.Role.Identifier != Models.Roles.Administrator)
                HttpContext.Current.Response.Redirect(_url);
        }

        private readonly string _url = "/Home/";

        public RequireAdminAuthentication(string url = "/Home/")
        {
            _url = url;
        }
    }
}
