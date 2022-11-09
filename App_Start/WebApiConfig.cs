using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting; /// added 

namespace TradeWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); 

            config.Formatters.Clear(); /// !
            config.Formatters.Add(new JsonMediaTypeFormatter()); /// ! 
        }
    }
}
