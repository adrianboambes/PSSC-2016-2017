using System.Web;
using System.Web.Optimization;

namespace UniversityLocal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/studentScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/studentModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/teacherScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/teacherModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/schoolSubjectScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/schoolSubjectModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/courseScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/courseModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/laboratoryScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/laboratoryModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/deanshipScript").Include(
                "~/Scripts/Custom/ajaxHelper.js",
                "~/Scripts/Custom/deanshipModule.js",
                "~/Scripts/Custom/commonModule.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
