using System.Web.Mvc;
using SMA.WebUI.Filters;

namespace NS.Fertiberiatech.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ProfileAllAttribute());
        }
    }
}
