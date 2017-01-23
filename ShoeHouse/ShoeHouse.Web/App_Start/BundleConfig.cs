using System.Web;
using System.Web.Optimization;

namespace ShoeHouse.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/store-public.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme-scripts").Include(
                        "~/Scripts/libraries/jquery.easing.1.3.js",
                        "~/Scripts/libraries/bootstrap.min.js",
                        "~/Scripts/libraries/jquery.waypoints.min.js",
                        "~/Scripts/libraries/theme.actions.js"));

            bundles.Add(new StyleBundle("~/Content/theme-css").Include(
                      "~/Content/animate.css",
                      "~/Content/icomoon.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
