using System.Web;
using System.Web.Optimization;

namespace WebSiteArchitect.ClientWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                        "~/Scripts/jQuery/jquery-3.1.1.min.js",
                        "~/Scripts/Bootstrap/bootstrap-select.min.js",
                        "~/Scripts/Bootstrap/bootstrap.min.js",                        
                        "~/Scripts/Bootstrap/jquery.dataTables.min.js",
                        "~/Scripts/Bootstrap/jQuery.fn.dataTables.colResize.js",
                        "~/Scripts/Main/DataTableControl.js",
                        "~/Scripts/Main/Dropdown.js",
                        "~/Scripts/Main/Main.js"));
            bundles.Add(new StyleBundle("~/css").Include(
                        "~/Content/Bootstrap/bootstrap-grid.min.css",
                        "~/Content/Bootstrap/bootstrap-reboot.min.css",
                        "~/Content/Bootstrap/bootstrap-select.min.css",
                        "~/Content/Bootstrap/bootstrap.min.css",
                        "~/Content/Bootstrap/jquery.dataTables.min.css",
                        "~/Content/fonts/font-awesome.min.css",
                        "~/Content/Style/Main.css"
                      ));

        }
    }
}