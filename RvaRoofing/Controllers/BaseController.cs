namespace RvaRoofing.Controllers
{
	using Helpers;
	using Models;
	using System.Web.Mvc;

	public class BaseController : Controller
	{
		private RvaRoofingDataContext _rvaRoofing;

		public RvaRoofingDataContext RvaRoofingModel
		{
			get { return _rvaRoofing; }
		}
	}
}