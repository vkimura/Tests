using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.Models
{
    public class UserAgentInfo : UserAgentInfoBase
    {
        public int MyProperty { get; set; }
        public string UserAgentBrowserInfo { get; set; }
        public string BrowserUsed { get; set; }
        public string Android { get; set; }
        public string OSXOS { get; set; }
        public string iPhone { get; set; }
        public string Edge { get; set; }
        public string IE { get; set; }
        public string Firefox { get; set; }
        public string Opera { get; set; }
        public string Chrome { get; set; }
        public string ChromeOS { get; set; }
        public string LinuxOS { get; set; }

        public string Motorola { get; set; }
        public string AndroidOS { get; set; }

        public string WindowsOS { get; set; }

        public string Huawei { get; set; }
        public string OperaMini { get; set; }

        public string Facebook { get; set; }

        public string  HTMLCode { get; set; }

        public void BrowserName()
        {
            
        }
    }

}