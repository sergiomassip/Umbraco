using NS.Fertiberiatech.Web.Components;
using NS.Fertiberiatech.Web.Configuration;
using NS.Fertiberiatech.Web.Controllers.MVC;
using Umbraco.Core.Composing;
using Umbraco.Core;

namespace NS.Fertiberiatech.Web.Composer
{
    public class RegisterDependencies : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IConfiguration, Configuration.Configuration>(Lifetime.Singleton);
            composition.Components().Append<AttributeRoutingComponent>();
            
            // Controllers
            composition.Register<TestController>(Lifetime.Request);

            composition.Components().Append<RouteTableComponent>();
            composition.Components().Append<BundleConfigComponent>();
            composition.Components().Append<FilterConfigComponent>();
        }
    }
}