namespace RvaRoofing.App_Start
{
	using System.Web.Optimization;

	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/Less/Site.less"));

			bundles.Add(new ScriptBundle("~/Scripts").Include(
				"~/Scripts/jquery-{version}.js",
				"~/Scripts/jquery-ui-{version}.js",
				"~/Scripts/jquery.validate.js",
				"~/Scripts/jquery.validate.unobtrusive.js",
				"~/Scripts/less-{version}.js",
				"~/Scripts/Global.js"));
		}
	}
}