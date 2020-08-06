using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FileHandling.Helper
{
    public class FileConfig : IFileConfig
    {
        /// <summary>
        /// Get the FileLocation field value from the Appsettings
        /// </summary>
        public string FilePath => ConfigurationManager.AppSettings["FileLocation"];

        /// <summary>
        /// Get the FileNotFound text from the Appsettings file
        /// </summary>
        public string FileNotFound => ConfigurationManager.AppSettings["FileNotFound"];
    }
}