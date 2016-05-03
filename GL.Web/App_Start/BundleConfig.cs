using System.Web;
using System.Web.Optimization;

namespace GL.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/kendo/2016.1.112/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/2016.1.112/kendo.all.min.js",
                        "~/Scripts/kendo/2016.1.112/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo/2016.1.112/kendo.timezones.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/demo").Include(
            //            "~/Scripts/kendo/2016.1.112/console.js",
            //            "~/Scripts/kendo/2016.1.112/prettify.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                        "~/Content/kendo/2016.1.112/kendo.common.min.css",
                        "~/Content/kendo/2016.1.112/kendo.rtl.min.css",
                        "~/Content/kendo/2016.1.112/kendo.default.min.css",
                        "~/Content/kendo/2016.1.112/kendo.default.mobile.min.css",
                        "~/Content/kendo/2016.1.112/kendo.dataviz.min.css",
                        "~/Content/kendo/2016.1.112/kendo.dataviz.default.min.css",
                        "~/Content/kendo/2016.1.112/kendo.mobile.all.min.css"));


            bundles.Add(new StyleBundle("~/Content/mobile/css").Include(
                        "~/Content/kendo/2016.1.112/kendo.mobile.all.min.css"));

            bundles.IgnoreList.Clear();

        }
    }
}
