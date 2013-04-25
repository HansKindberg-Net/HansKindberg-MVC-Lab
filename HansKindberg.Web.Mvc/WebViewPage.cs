using System;
using System.Web.Mvc;

namespace HansKindberg.Web.Mvc
{
	public abstract class WebViewPage : WebViewPage<object>
	{
		#region Constructors

		protected WebViewPage() {}
		protected WebViewPage(IHtmlHelperDependency htmlHelperDependency) : base(htmlHelperDependency) {}

		#endregion
	}

	public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
	{
		#region Fields

		private readonly IHtmlHelperDependency _htmlHelperDependency;

		#endregion

		#region Constructors

		protected WebViewPage() : this(DependencyResolver.Current.GetService<IHtmlHelperDependency>()) {}

		protected WebViewPage(IHtmlHelperDependency htmlHelperDependency)
		{
			if(htmlHelperDependency == null)
				throw new ArgumentNullException("htmlHelperDependency");

			this._htmlHelperDependency = htmlHelperDependency;
		}

		#endregion

		#region Properties

		public new virtual HtmlHelper<TModel> Html { get; set; }

		protected virtual IHtmlHelperDependency HtmlHelperDependency
		{
			get { return this._htmlHelperDependency; }
		}

		#endregion

		#region Methods

		public override void InitHelpers()
		{
			this.Ajax = new AjaxHelper<TModel>(this.ViewContext, this);
			this.Html = new HtmlHelper<TModel>(this.ViewContext, this, this.HtmlHelperDependency);
			this.Url = new UrlHelper(this.ViewContext.RequestContext);
		}

		#endregion
	}
}