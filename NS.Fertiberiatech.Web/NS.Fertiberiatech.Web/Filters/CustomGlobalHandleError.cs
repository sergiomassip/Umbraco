﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMA.WebUI.Filters
{
    public class CustomGlobalHandleError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Trace.TraceError(filterContext.Exception.Message);
            base.OnException(filterContext);
        }
    }
}