using System.Web.Routing;

// ReSharper disable once CheckNamespace
namespace System.Web.Mvc.Html
{

    public static class ActionLinkButtonHelper
    {
        public static MvcHtmlString ActionLinkButton(this HtmlHelper htmlHelper, string buttonText, string actionName, string controllerName)
        {
            var href = UrlHelper.GenerateUrl("default", actionName, controllerName, new RouteValueDictionary(), RouteTable.Routes, htmlHelper.ViewContext.RequestContext, false);
            var buttonHtml = string.Format("<input type=\"button\" title=\"{0}\" value=\"{0}\" onclick=\"location.href='{1}'\" class=\"button\" />", buttonText, href);
            return new MvcHtmlString(buttonHtml);
        }

        public static MvcHtmlString ActionLinkButton(this HtmlHelper htmlHelper, string buttonText, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            var href = UrlHelper.GenerateUrl("default", actionName, controllerName, routeValues, RouteTable.Routes, htmlHelper.ViewContext.RequestContext, false);
            var buttonHtml = string.Format("<input type=\"button\" title=\"{0}\" value=\"{0}\" onclick=\"location.href='{1}'\" class=\"button\" />", buttonText, href);
            return new MvcHtmlString(buttonHtml);
        }
    }
}
