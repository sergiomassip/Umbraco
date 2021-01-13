using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using NS.Fertiberiatech.Web.PublishedContentModels;

namespace NS.Fertiberiatech.Web.Controllers.Umbraco
{
    public class HomeController : RenderMvcController
    {
        // GET: Home
        public override ActionResult Index(ContentModel model)
        {
            var home = new Home(model.Content);

            return CurrentTemplate(home);

        }
    }
}