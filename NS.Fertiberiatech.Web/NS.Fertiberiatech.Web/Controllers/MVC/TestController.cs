using System.Web.Mvc;
using SMA.WebUI.Filters;

namespace NS.Fertiberiatech.Web.Controllers.MVC
{
    public class TestController : Controller
    {
        // GET: Test
        [OutputCache(Duration = 3600)]
        [ProfileAllAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}