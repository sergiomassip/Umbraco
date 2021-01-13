using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;

namespace NS.Fertiberiatech.Web.Components
{
    public class RouteTableComponent : IComponent
    {
        public void Initialize()
        {
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                "Test",
                "Test",
                new
                {
                    controller = "Test",
                    action = "Index",
                    id = UrlParameter.Optional
                });


            RouteTable.Routes.MapRoute(
                "DI",
                "DI",
                new
                {
                    controller = "Di",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }

        public void Terminate()
        {
           
        }
    }
}