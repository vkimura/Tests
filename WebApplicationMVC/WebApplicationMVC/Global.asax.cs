using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplicationMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /*WebApiConfig.Register(GlobalConfiguration.Configuration);*/
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44391");
                Response.Headers.Add("Access-Control-Allow-Headers",
                  "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                Response.Flush();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }
    }
}
