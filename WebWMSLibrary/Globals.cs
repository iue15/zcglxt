using System;
using System.Data;
using System.Configuration;

namespace WebWMS
{
    public static class Globals
    {
        //"OrderSalesInventorySection" is defined in App.config and file ConfigSection
        public readonly static WebWMSSection  Settings = (WebWMSSection)ConfigurationManager.GetSection("WebWMSSection");
        public static string ThemesSelectorID = "";
        static Globals()
        {

        }

    }
}

