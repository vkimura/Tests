using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;
using WebApplicationMVC.Cors;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {

        public string BrowserName;
        public bool Gecko;
        public bool Safari;
        public bool OSX;

        /*TODO: how do I create the model useragentinfo variable to be available to the other methods. Refactor new UserAgentInfo to remove code duplication: https://www.geeksforgeeks.org/c-sharp-constructors/*/
        /*public HomeController(HomeController s)
        {
            s.DetermineUserAgentBrowser();

            UserAgentInfo useragentinfo = new UserAgentInfo
            {
                BrowserUsed = BrowserName
            };

        }*/

        [AllowCrossSite]
        public void DetermineUserAgentBrowser()
        {
            Gecko = Request.UserAgent.Contains("KHTML, like Gecko");
            Safari = Request.UserAgent.Contains("Safari");
            OSX = Request.UserAgent.Contains("OS X");

            /*Determine which browser is used.*/
            if (Gecko && Safari && OSX == false)
            {
                BrowserName = "Chrome";
            }
            else if (Safari && OSX)
            {
                BrowserName = "Safari";
            }
            else
            {
                BrowserName = "Chrome";
            }
        }

        [AllowCrossSite]
        public ActionResult Index()
        {

            DetermineUserAgentBrowser();

            UserAgentInfo useragentinfo = new UserAgentInfo
            {
                BrowserUsed = BrowserName
            };

            ViewBag.UserAgentInfo = useragentinfo;

            return View();
        }

        [AllowCrossSite]
        public ActionResult About()
        {

            DetermineUserAgentBrowser(); 

            UserAgentInfo useragentinfo = new UserAgentInfo
            {
                BrowserUsed = BrowserName
            };

            ViewBag.UserAgentInfo = useragentinfo;
            ViewBag.Message = "Your application description page.";
            ViewBag.UserAgent = Request.UserAgent;
            ViewBag.UserHostAddress = Request.UserHostAddress;
            ViewBag.UserHostName = Request.UserHostName;

            return View();
        }

        [AllowCrossSite]
        public ActionResult Contact()
        {

            DetermineUserAgentBrowser();

            UserAgentInfo useragentinfo = new UserAgentInfo
            {
                BrowserUsed = BrowserName
            };

            ViewBag.UserAgentInfo = useragentinfo;

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}