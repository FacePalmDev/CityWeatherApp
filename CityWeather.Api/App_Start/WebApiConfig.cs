using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace CityWeather.Api
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
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Services.Add(typeof(IExceptionLogger), new SerilogExceptionLogger());


        }

    }
}
