using System.Web;
using System.Web.Optimization;

namespace OnlineShop.Web.Telerik
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Scripts/CommonUI.js"
                
                ));

            bundles.Add(new ScriptBundle("~/bundles/KendoJs").Include(
                //"~/Scripts/kendo/2015.1.318/jquery.min.js",
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/kendo/2015.1.318/jszip.min.js",
                "~/Scripts/kendo/2015.1.318/kendo.all.min.js",
                "~/Scripts/kendo/2015.1.318/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js",
                "~/Scripts/fileinput.min.js"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-fileinput/css/fileinput.css"));

            bundles.Add(new StyleBundle("~/KendoContent/css").Include(
                "~/Content/kendo/2015.1.318/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2015.1.318/kendo.mobile.all.min.css",
                "~/Content/kendo/2015.1.318/kendo.dataviz.min.css",
                "~/Content/kendo/2015.1.318/kendo.bootstrap.min.css",
                "~/Content/kendo/2015.1.318/kendo.dataviz.bootstrap.min.css"
                ));

        }
    }
}
