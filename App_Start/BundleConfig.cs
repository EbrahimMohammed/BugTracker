using System.Web;
using System.Web.Optimization;

namespace BugTracker
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/metisMenu.min.js",
                "~/Scripts/jquery.slimscroll.js",
                "~/Scripts/waves.min.js",
                "~/plugins/jquery-sparkline/jquery.sparkline.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));
            
            
            bundles.Add(new ScriptBundle("~/bundles/chartsjs").Include(
                "~/plugins/morris/morris.min.js",
                "~/plugins/c3/c3.min.js",
                "~/plugins/d3/d3.min.js",
                "~/plugins/raphael/raphael-min.js"));




                bundles.Add(new ScriptBundle("~/bundles/pluginsjs").Include(
                    "~/plugins/datatables/jquery.datatables.min.js",
                    "~/plugins/datatables/datatables.bootstrap4.min.js",
                    "~/plugins/datatables/dataTables.buttons.min.js",
                    "~/plugins/datatables/buttons.bootstrap4.min.js",
                    "~/plugins/datatables/jszip.min.js",
                    "~/plugins/datatables/pdfmake.min.js",
                    "~/plugins/datatables/vfs_fonts.js",
                    "~/plugins/datatables/buttons.html5.min.js",
                    "~/plugins/datatables/buttons.print.min.js",
                    "~/plugins/datatables/buttons.colVis.min.js",
                    "~/plugins/datatables/dataTables.responsive.min.js",
                    "~/plugins/datatables/responsive.bootstrap4.min.js",
                    "~/plugins/datatables/Select-1.3.1/js/*.js",
                    "~/plugins/select2/js/select2.js",
                    "~/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                    "~/plugins/toaster/toaster.js",
                    "~/plugisn/parsleyjs/parsley.min.js",
                    "~/plugins/toastr/toastr.js"

                ));


             bundles.Add(new ScriptBundle("~/bundles/swal").Include(
                       "~/plugins/sweet-alert2/sweetalert2.all.js"
             ));







             
                bundles.Add(new StyleBundle("~/bundles/pluginscss").Include(
                    "~/plugins/datatables/dataTables.bootstrap4.min.css",
                    "~/plugins/datatables/buttons.bootstrap4.min.css",
                    "~/plugins/datatables/responsive.bootstrap4.min.css",
                    "~/plugins/datatables/Select-1.3.1/css/*.css",
                    "~/plugins/select2/css/select2.min.css",
                    "~/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                    "~/plugins/toastr/toastr.css"

            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/metismenu.min.css",
                "~/Content/icons.css",
                "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/plugins/swal").Include(
                "~/plugins/sweet-alert2/sweetalert2.min.css")); 
            
            
            bundles.Add(new StyleBundle("~/plugins/chartscss").Include(
                "~/plugins/morris/morris.css",
                "~/plugins/c3/c3.min.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/fontawesome/font-awesome.css"));

        }
    }
}