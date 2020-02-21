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
            bundles.Add(new StyleBundle("~/Content/Homepage/css").Include(
                      "~/Content/Homepage/css/linearicons.css",
                      "~/Content/Homepage/css/font-awesome.min.css",
                      "~/Content/Homepage/css/bootstrap.css",
                      "~/Content/Homepage/css/magnific-popup.css",
                      "~/Content/Homepage/css/nice-select.css",
                      "~/Content/Homepage/css/animate.min.css",
                      "~/Content/Homepage/css/owl.carousel.css",
                      "~/Content/Homepage/css/main.css"));

            bundles.Add(new ScriptBundle("~/Content/Homepage/js").Include(
                    "~/Content/Homepage/js/vendor/jquery-2.2.4.min.js",
                    "~/Content/Homepage/js/vendor/bootstrap.min.js",
                    "~/Content/Homepage/js/easing.min.js",
                    "~/Content/Homepage/js/hoverIntent.js",
                    "~/Content/Homepage/js/superfish.min.js",
                    "~/Content/Homepage/js/jquery.ajaxchimp.min.js",
                    "~/Content/Homepage/js/jquery.magnific-popup.min.js",
                    "~/Content/Homepage/js/owl.carousel.min.js",
                    "~/Content/Homepage/js/imagesloaded.pkgd.min.js",
                    "~/Content/Homepage/js/justified.min.js",
                    "~/Content/Homepage/js/jquery.sticky.js",
                    "~/Content/Homepage/js/jquery.nice-select.min.js",
                    "~/Content/Homepage/js/parallax.min.js",
                    "~/Content/Homepage/js/mail-script.js",
                    "~/Content/Homepage/js/main.js"));
            //AdminPage
            bundles.Add(new ScriptBundle("~/Content/Js").Include(
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
