using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Clockwork.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/main-layout").Include(
                        "~/Content/lib/jQuery/dist/jquery.js",
                        "~/Content/lib/bootstrap/dist/js/bootstrap.js",
                       "~/Content/lib/jquery-validation/dist/jquery.validate.min.js",
                       "~/Content/lib/Microsoft.jQuery.Unobtrusive.Ajax/jquery.unobtrusive-ajax.js",
                       "~/Content/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js",
                       "~/Content/js/site.js",
                       "~/Content/js/navigation.js",
                       "~/Content/lib/toastr/toastr.min.js"));

         
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/lib/bootstrap/dist/css/bootstrap.css",
                       "~/Content/lib/font-awesome/css/font-awesome.css",
                       "~/Content/lib/toastr/toastr.min.css",
                        "~/Content/css/site.css",
                       "~/Content/css/skin-blue.css"));
        }
    }
}