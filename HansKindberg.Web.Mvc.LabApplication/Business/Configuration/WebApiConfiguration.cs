using System.Web.Http;

namespace HansKindberg.Web.Mvc.LabApplication.Business.Configuration
{
	public static class WebApiConfiguration
	{
		#region Methods

		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new {id = RouteParameter.Optional}
				);
		}

		#endregion
	}
}