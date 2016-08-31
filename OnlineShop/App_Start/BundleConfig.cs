using System.Web;
using System.Web.Optimization;

namespace OnlineShop
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Scripts/admin/jqery.dataTables.min.js",
                 "~/Scripts/vendors/jquery-1.12.4.js",
                "~/Scripts/vendors/paper-dashboard.js",
                "~/Scripts/vendors/jquery-ui-1.12.0.js",
                "~/Scripts/jquery.jqGrid.min.js",
               "~/Scripts/vendors/bootstrap.min.js",
                "~/Scripts/admin/bootstrap-checkbox-radio.js",
                "~/Scripts/admin/bootstrap-notify.js",
                "~/Scripts/admin/chartist.min.js",
                "~/Scripts/admin/demo.js"));
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/jquery.js",
                "~/Scripts/vendors/bootstrap.min.js",
                "~/Scripts/vendors/classie.js",
                "~/Scripts/vendors/imagezoom.js",
                "~/Scripts/vendors/jquery-ui.min.js",
                "~/Scripts/vendors/jquery.unobtrusive-ajax.js",
                "~/Scripts/vendors/jquery-ui-1.12.0.min.js",
                "~/Scripts/vendors/jquery-1.12.4.min.js",
                "~/Scripts/vendors/jquery.chocolate.js",
                "~/Scripts/vendors/jquery.etalage.min.js",
                "~/Scripts/vendors/jquery.flexslider.js",
                "~/Scripts/vendors/jquery.jscrollpane.min.js",
                "~/Scripts/vendors/jquery.magnific-popup.js",
                "~/Scripts/vendors/jquery.min.js",
                "~/Scripts/vendors/jstarbox.js",
                "~/Scripts/vendors/megamenu.js",
                "~/Scripts/vendors/menu_jquery.js",
                "~/Scripts/vendors/modernizr.custom.72111.js",
                "~/Scripts/vendors/simpleCart.min.js",
                "~/Scripts/vendors/uisearch.min.js"));
            bundles.Add(new StyleBundle("~/Content/admin").Include(
                "~/Content/css/jquery.dataTables.min.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/demo.css",
                "~/Content/css/paper-dashboard.css",
                "~/Content/css/themify-icons.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/themes/base/jquery.ui.all.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"));
            bundles.Add(new StyleBundle("~/Content/menu").Include(
                "~/Content/css/megamenu.css",
                 "~/Content/css/bootstrap.css",
                 "~/Content/css/style.css"));
            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                "~/Scripts/vendors/megamenu.js",
                "~/Scripts/vendors/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/chocolat.css",
                      "~/Content/css/etalage.css",
                      "~/Content/css/flexslider.css",
                      "~/Content/css/form.css",
                      "~/Content/css/jstarbox.css",
                      "~/Content/css/megamenu.css",
                      "~/Content/css/popuo-box.css",
                      "~/Content/css/style4.css"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/app.js"));
        }
    }
}
