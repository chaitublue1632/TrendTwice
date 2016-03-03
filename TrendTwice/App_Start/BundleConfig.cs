using System.Web;
using System.Web.Optimization;

namespace TrendTwice
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/fileinput").Include(                      
                      "~/Scripts/fileinput/fileinput.min.js",
                      "~/Scripts/fineuploader/jquery.fine-uploader.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/custom.css"));

            bundles.Add(new StyleBundle("~/Content/wizard").Include(
                       "~/Content/wizard/gsdk-base.css"));

            bundles.Add(new StyleBundle("~/Content/fileinput").Include(
                       "~/Content/fileinput/fileinput.min.css",
                       "~/Content/fineuploader/fine-uploader-gallery.min.css"));

        }
    }
}
