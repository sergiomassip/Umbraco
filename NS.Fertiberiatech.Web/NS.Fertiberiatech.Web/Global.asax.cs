using System;
using System.Web.Mvc;
using SMA.WebUI.Filters;
using Umbraco.Web;

namespace NS.Fertiberiatech.Web
{
    public  class Global : UmbracoApplication
    {
        protected override void OnApplicationError(object sender, EventArgs evargs)
        {
            base.OnApplicationError(sender, evargs);

        }
        
        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //   /* filters.Add(new ProfileAllAttribute ());*/
        //}
    }
}