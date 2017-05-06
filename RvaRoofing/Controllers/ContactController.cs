namespace RvaRoofing.Controllers
{
	using System.Web.Mvc;
	using ViewModels;

	public class ContactController : Controller
	{
		public ActionResult Index()
		{
			return View(new ContactViewModel());
		}
	}
}