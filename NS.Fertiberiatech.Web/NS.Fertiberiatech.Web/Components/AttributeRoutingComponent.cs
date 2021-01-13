using System.Web.Http;
using Umbraco.Core.Composing;

namespace NS.Fertiberiatech.Web.Components
{
    public class AttributeRoutingComponent : IComponent
    {
        public void Initialize()
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
        }

        public void Terminate()
        {
           
        }
    }
}