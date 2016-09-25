using ProjectSem3.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectSem3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.Add(
            //new Route("{controller}/{action}/{id}",
            //    new RouteValueDictionary(
            //        new { controller = "Customer", action = "Index", id = "" }),
            //        new HyphenatedRouteHandler()
            //    )
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectSem3.Controllers" }
            );



        }
    }
}
