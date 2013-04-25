using System.Threading;
using System.Web.Mvc;
using HansKindberg.Web.Mvc.LabApplication.Models;

namespace HansKindberg.Web.Mvc.LabApplication.Controllers
{
	public class HomeController : Controller
	{
		#region Methods

		public virtual ActionResult Index()
		{
			return this.View(new HomeViewModel {Culture = Thread.CurrentThread.CurrentUICulture});
		}

		#endregion
	}
}