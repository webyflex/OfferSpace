using System.Web.Optimization;

namespace OfferSpace.Web
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/LandingScripts/js").Include(
              "~/Scripts/LandingScripts/jquery.min.js",                  // jQuery
              "~/Scripts/LandingScripts/jquery.easing.1.3.js",           // jQuery Easing
              "~/Scripts/LandingScripts/bootstrap.min.js",               // Bootstrap
              "~/Scripts/LandingScripts/jquery.waypoints.min.js",        // Waypoints
              "~/Scripts/LandingScripts/jquery.stellar.min.js",          // Stellar Parallax
              "~/Scripts/LandingScripts/jquery.flexslider-min.js",       // Flexslider
              "~/Scripts/LandingScripts/owl.carousel.min.js",            // Owl carousel
              "~/Scripts/LandingScripts/query.magnific-popup.min.js",    // Magnific Popup
              "~/Scripts/LandingScripts/magnific-popup-options.js",      // Magnific Popup
              "~/Scripts/LandingScripts/jquery.countTo.js",              // Counters
              "~/Scripts/LandingScripts/main.js"));                      // Main

            bundles.Add(new ScriptBundle("~/bundles/LandingScripts/js").Include(
              "~/Scripts/CreatingSteper/jquery-2.2.4.min.js",
              "~/Scripts/CreatingSteper/jquery.bootstrap.js",
              "~/Scripts/CreatingSteper/jquery.validate.min.js",
              "~/Scripts/CreatingSteper/material-bootstrap-wizard.js"));

      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/LandingStyles/css").Include(
              "~/Content/LandingStyles/animate.css",                // Animate.css
              "~/Content/LandingStyles/bootstrap.css",              // Bootstrap
              "~/Content/LandingStyles/icomoon.css",                // Icomoon Icon Fonts
              "~/Content/LandingStyles/magnific-popup.css",         // Magnific Popup
              "~/Content/LandingStyles/flexslider.css",             // Flexslider
              "~/Content/LandingStyles/owl.carousel.min.css",       // Owl Carousel
              "~/Content/LandingStyles/owl.theme.default.min.css",  // Owl Carousel
              "~/Content/LandingStyles/flaticon.css",               // Flaticons
              "~/Content/LandingStyles/style.css"));                // Theme style

          bundles.Add(new StyleBundle("~/Content/LoginAndRegisterStyles/css").Include(
            "~/Content/LoginAndRegisterStyles/Login.css",
            "~/Content/LoginAndRegisterStyles/RegisterCust.css"
            ));

        }
    }
}
