﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplicationMVC.Cors
{
    public class AllowCrossSiteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "https://localhost:44391");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "*");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Vary", "Origin");


            base.OnActionExecuting(filterContext);
        }
    }
}