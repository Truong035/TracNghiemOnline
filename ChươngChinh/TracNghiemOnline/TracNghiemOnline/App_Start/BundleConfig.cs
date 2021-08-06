using System.Web;
using System.Web.Optimization;

namespace TracNghiemOnline
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
            bundles.Add(new ScriptBundle("~/bundles/importfile").Include(
                    "~/assets/demo/datatables1-demo.js",
                    "~/assets/Importfile/file1.js",
                    "~/assets/Importfile/file2.js",
                    "~/assets/Importfile/file3.js",
                    "~/assets/Importfile/file4.js",
                    "~/assets/Importfile/file5.js",
                    "~/assets/Importfile/file6.js",
                    "~/assets/Importfile/file7.js"

                      ));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
        "~/assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js",
        "~/assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js",
        "~/assets/js/atlantis.min.js",
        "~/assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"
          ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                       "~/assets/css/bootstrap.min.css",
                      "~/assets/css/atlantis.min.css"


                      ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
