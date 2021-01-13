using System.Web.Mvc;

namespace SMA.WebUI.Filters
{
    public class CustomErrorHandler : FilterAttribute, IExceptionFilter {

        public void OnException(ExceptionContext filterContext)
        {
            //throw new NotImplementedException();
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}
