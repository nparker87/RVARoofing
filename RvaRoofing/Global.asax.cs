namespace RvaRoofing
{
	using App_Start;
	using System.Web.Mvc;
	using System.Web.Optimization;
	using System.Web.Routing;

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}