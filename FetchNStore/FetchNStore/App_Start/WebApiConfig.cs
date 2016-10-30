using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FetchNStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               //There is no default controller or default action. The reason ID are optional, is because API endpoints have multiple actions
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
