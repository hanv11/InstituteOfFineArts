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
                      "~/Content/Homepage/css/bootstrap.min.css",
                      "~/Content/Homepage/css/font-awesome.min.css",
                      "~/Content/Homepage/css/elegant-icons.css",
                      "~/Content/Homepage/css/nice-select.css",
                      "~/Content/Homepage/css/owl.carousel.min.css",
                      "~/Content/Homepage/css/magnific-popup.css",
                      "~/Content/Homepage/css/slicknav.min.css",
                      "~/Content/Homepage/css/style.css",
                      "~/Content/Homepage/vendor/fontawesome-free/css/all.min.css"));
            bundles.Add(new ScriptBundle("~/Content/Homepage/js").Include(
                    "~/Homepage/js/jquery-3.3.1.min.js",
                    "~/Homepage/js/bootstrap.min.js",
                    "~/Homepage/js/jquery.magnific-popup.min.js",
                    "~/Homepage/js/mixitup.min.js",
                    "~/Homepage/js/jquery.nice-select.min.js",
                    "~/Homepage/js/jquery.slicknav.js",
                    "~/Homepage/js/owl.carousel.min.js",
                    "~/Homepage/js/masonry.pkgd.min.js",
                    "~/Homepage/js/main.js"));
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
