using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS.Fertiberiatech.Web.Configuration
{
    public class Configuration : IConfiguration
    {
        public string AppName { get ; set ; }

        public Configuration() {
            AppName = "NS.Fertiberiatech.Web";
        }
    }
}