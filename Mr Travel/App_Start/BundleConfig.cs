﻿using System.Web;
using System.Web.Optimization;

namespace Mr_Travel
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

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                         "~/Scripts/jquery.min.js",
                         "~/Scripts/moment.min.js",
                         "~/Scripts/fullcalendar.js",
                         "~/Scripts/calendar.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapbox").Include(
                      "~/Scripts/location.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));
        }
    }
}
