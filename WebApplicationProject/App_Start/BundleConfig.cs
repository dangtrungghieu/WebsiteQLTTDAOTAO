using System.Web;
using System.Web.Optimization;

namespace WebApplicationProject
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/cssProject").Include("~/Content/StyleProject.css"));
            bundles.Add(new ScriptBundle("~/Script/jsProject").Include("~/Scripts/script.js"));
            bundles.Add(new StyleBundle("~/Content/cssLoginRegisterUser").Include("~/Content/StyleLoginUser.css"));
            bundles.Add(new ScriptBundle("~/Script/jsLoginRegisterUser").Include("~/Scripts/ScriptLoginUser.js"));
            bundles.Add(new StyleBundle("~/Content/styleAdmin").Include("~/Content/styleAdmin.css", "~/Content/StyleCreate.css"));
            bundles.Add(new StyleBundle("~/Content/cssLoginAdmin").Include("~/Content/cssLoginAdmin.css"));
            bundles.Add(new StyleBundle("~/Content/ProFile").Include("~/Content/profile.css"));
        }
    }
}
