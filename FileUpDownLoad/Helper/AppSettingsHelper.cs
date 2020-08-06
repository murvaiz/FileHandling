using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FileUpDownLoad.Helper
{
    public static class AppSettingsHelper
    {
        public static string GetApi(string api)
        {
            return ConfigurationManager.AppSettings["Api"];
        }
    }
}
