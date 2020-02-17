using System.Web;
using System.Web.Optimization;

namespace InstituteOfFineArts
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Homepage
            bundles.Add(new StyleBundle("~/Homepage/css").Include(
                      "~/Content/Homepage/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Homepage/css/agency.min.css",
                      "~/Content/Homepage/vendor/fontawesome-free/css/all.min.css"));
            bundles.Add(new ScriptBundle("~/Homepage/js").Include(
                    "~/Scripts/Homepage/vendor/jquery/jquery.min.js",
                    "~/Scripts/Homepage/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Scripts/Homepage/js/jqBootstrapValidation.js",
                    "~/Scripts/Homepage/js/contact_me.js",
                    "~/Scripts/Homepage/js/agency.min.js",
                    "~/Scripts/Homepage/vendor/jquery-easing/jquery.easing.min.js"));
            //AdminPage
            bundles.Add(new ScriptBundle("~/Js").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery.validate*",
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/jquery.validate*",
            "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
            "~/Content/plugins/fastclick/fastclick.js",
            "~/Content/dist/js/app.min.js",
            "~/Content/dist/js/demo.js"));
            bundles.Add(new StyleBundle("~/Css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css"));
        }
    }
}
