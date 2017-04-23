namespace RvaRoofing.Controllers
{
	using System.Web.Mvc;
	using ViewModels;

	public class PrivacyController : Controller
	{
		public ActionResult Index()
		{
			var viewModel = new BaseViewModel
			{
				CurrentTab = "Privacy"
			};

			return View(viewModel);
		}
	}
}