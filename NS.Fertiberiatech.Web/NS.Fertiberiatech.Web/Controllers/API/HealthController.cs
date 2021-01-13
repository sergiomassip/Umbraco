using System.Web.Http;
using Umbraco.Web.WebApi;

namespace NS.Fertiberiatech.Web.Controllers.API
{
    public class HealthController : UmbracoApiController
    {
       // https://localhost:44386/umbraco/api/health/get
       // https://localhost:44386/api/health
       [HttpGet, Route("api/v1/health")]
       public string Get()
       {
            return "Ok";
       }
    }
}
