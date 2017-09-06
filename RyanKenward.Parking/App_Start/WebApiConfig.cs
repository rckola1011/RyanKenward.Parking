using System.Web.Http;

namespace RyanKenward.Parking
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			/*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

			config.Routes.MapHttpRoute(
				name: "GetAvailableParkingSpaces",
				routeTemplate: "api/{controller}/Spaces/",
				defaults: new { controller = "Parking", action = "Spaces" }
			);

			config.Routes.MapHttpRoute(
				name: "GetParkingFee",
				routeTemplate: "api/{controller}/Fee",
				defaults: new { controller = "Parking", action = "Fee" }
			);
        }
    }
}
