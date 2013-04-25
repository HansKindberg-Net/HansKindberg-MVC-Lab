using System.Web.Mvc;

namespace HansKindberg.Web.Mvc.LabApplication.Business.Configuration
{
	public class FilterConfiguration
	{
		#region Methods

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		#endregion
	}
}