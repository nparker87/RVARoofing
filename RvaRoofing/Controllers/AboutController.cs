namespace RvaRoofing.Controllers
{
	using System.Web.Mvc;
	using ViewModels;

	public class AboutController : Controller
	{
		public ActionResult Index()
		{
			var viewModel = new BaseViewModel
			{
				CurrentTab = "About"
			};

			return View(viewModel);
		}
	}
}