using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Core.Composing;

namespace NS.Fertiberiatech.Web.Components
{
    public class FilterConfigComponent : IComponent
    {
        public void Initialize()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public void Terminate()
        {
           
        }

       
    }
}