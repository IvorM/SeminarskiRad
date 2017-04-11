using System.Web;
using System.Web.Optimization;

namespace SeminarskiRad
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/respond.js",
                         "~/Scripts/metisMenu.min.js",
                         "~/Scripts/sb-admin-2.js",
                         "~/Scripts/jquery.validate.min.js",
                         "~/Scripts/footable.all.min.js",
                         "~/Scripts/notify.min.js",
                         "~/Scripts/bootstrap-datepicker.min.js",
                         "~/Scripts/bootstrap-datepicker.hr.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/metisMenu.min.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/footable.core.css",
                      "~/Content/bootstrap-datepicker3.min.css"));
        }
    }
}
