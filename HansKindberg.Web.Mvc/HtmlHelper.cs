using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HansKindberg.Web.Mvc
{
	public class HtmlHelper : HtmlHelper<object>
	{
		#region Constructors

		public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, IHtmlHelperDependency htmlHelperDependency) : base(viewContext, viewDataContainer, htmlHelperDependency) {}
		public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection, IHtmlHelperDependency htmlHelperDependency) : base(viewContext, viewDataContainer, routeCollection, htmlHelperDependency) {}

		#endregion
	}

	public class HtmlHelper<TModel> : System.Web.Mvc.HtmlHelper<TModel>
	{
		#region Fields

		private readonly IHtmlHelperDependency _htmlHelperDependency;

		#endregion

		#region Constructors

		public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, IHtmlHelperDependency htmlHelperDependency) : this(viewContext, viewDataContainer, RouteTable.Routes, htmlHelperDependency) {}

		public HtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection, IHtmlHelperDependency htmlHelperDependency) : base(viewContext, viewDataContainer, routeCollection)
		{
			if(htmlHelperDependency == null)
				throw new ArgumentNullException("htmlHelperDependency");

			this._htmlHelperDependency = htmlHelperDependency;
		}

		#endregion

		#region Properties

		protected virtual IHtmlHelperDependency HtmlHelperDependency
		{
			get { return this._htmlHelperDependency; }
		}

		#endregion

		#region Methods

		public virtual IHtmlString GetValueFromDependency()
		{
			return this.HtmlHelperDependency.GetHtml();
		}

		#endregion
	}
}