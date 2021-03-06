﻿namespace InformationalVaults
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/moment").Include(
                "~/Scripts/moment*"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-material-datetimepicker").Include(
                "~/Scripts/bootstrap-material-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/select2").Include(
                "~/Scripts/select2*"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Styles/bootstrap-material-datetimepicker").Include(
                "~/Content/bootstrap-material-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Styles/select2").Include(
                "~/Content/css/select2*"));

            bundles.Add(new StyleBundle("~/Styles/site").Include(
                "~/Content/site.css"));
        }
    }
}