using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HansKindberg.Web.Mvc.InversionOfControl.StructureMap;
using HansKindberg.Web.Mvc.LabApplication.Business.Configuration;
using StructureMap;

namespace HansKindberg.Web.Mvc.LabApplication
{
	public class MvcApplication : System.Web.HttpApplication
	{
		#region Methods

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfiguration.Register(GlobalConfiguration.Configuration);
			FilterConfiguration.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfiguration.RegisterRoutes(RouteTable.Routes);

			ObjectFactory.Initialize(initializer => initializer.For<IHtmlHelperDependency>().Singleton().Use<HtmlHelperDependency>());

			DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
		}

		#endregion
	}
}