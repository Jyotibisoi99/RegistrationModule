using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Registration_Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "",
            //    url: "Rajendra",
            //    defaults: new { Controller = "Registration", action = "Display" }
            //    );
            //routes.MapRoute(
            //    name: "AJA",
            //    url: "aja/jyoti",
            //    defaults: new { controller = "registration", action = "insert" }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registration", action = "DisplayEmpList", id = UrlParameter.Optional }
            );
        }
    }
}
