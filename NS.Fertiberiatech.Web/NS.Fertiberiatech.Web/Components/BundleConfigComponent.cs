using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Core.Composing;

namespace NS.Fertiberiatech.Web.Components
{
    public class BundleConfigComponent : IComponent
    {
        public void Initialize()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Terminate()
        {
           
        }

        /*
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }*/

    }
}