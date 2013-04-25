using System.Web;
using System.Web.Mvc;

namespace HansKindberg.Web.Mvc
{
	public class HtmlHelperDependency : IHtmlHelperDependency
	{
		#region Methods

		public virtual IHtmlString GetHtml()
		{
			TagBuilder tagBuilder = new TagBuilder("p")
				{
					InnerHtml = "This value comes from a HtmlHelper-dependency."
				};

			return new HtmlString(tagBuilder.ToString(TagRenderMode.Normal));
		}

		#endregion
	}
}