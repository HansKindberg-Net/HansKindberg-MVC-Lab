using System.Web.Mvc;
using System.Web.Routing;

namespace HansKindberg.Web.Mvc.LabApplication.Business.Configuration
{
	public class RouteConfiguration
	{
		#region Methods

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
				);
		}

		#endregion
	}
}