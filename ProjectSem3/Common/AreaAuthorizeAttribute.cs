using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectSem3.Common
{
    public class AreaAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //string area = filterContext.RouteData.Values.ContainsKey("area")
            //                ? filterContext.RouteData.Values["area"].ToString()
            //                : null;
            string area = filterContext.RouteData.DataTokens["area"].ToString();
            string loginUrl = "";

            if (area == "Admin")
            {
                //    RouteValueDictionary routeValues = new RouteValueDictionary
                //{
                //    {"controller" , "Login"},
                //    {"action" , "Index"},
                //    {"area" , "Admin"}
                // };
                //filterContext.Result = new RedirectToRouteResult("AdminAreaRoute", routeValues);
                loginUrl = "~/Admin/Account/Login";

                filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.PathAndQuery);
            }
        }
    }
}