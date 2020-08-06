using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileHandling.Helper
{
    public interface IFileConfig
    {
        string FilePath { get; }
        string FileNotFound { get; }
    }
}