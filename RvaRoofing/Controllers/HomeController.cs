namespace RvaRoofing.Controllers
{
	using System.Web.Mvc;
	using ViewModels;

	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			var viewModel = new BaseViewModel();

			return View(viewModel);
		}
	}
}