using System.Web;

namespace HansKindberg.Web.Mvc
{
	public interface IHtmlHelperDependency
	{
		#region Methods

		IHtmlString GetHtml();

		#endregion
	}
}