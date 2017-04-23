namespace RvaRoofing.Controllers
{
	using System.Web.Mvc;
	using ViewModels;

	public class ContactController : Controller
	{
		public ActionResult Index()
		{
			var viewModel = new BaseViewModel
			{
				CurrentTab = "Contact"
			};

			return View(viewModel);
		}
	}
}