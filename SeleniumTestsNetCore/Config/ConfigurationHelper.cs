using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SeleniumTestsNetCore.Config
{
    public class ConfigurationHelper
    {
        public static string SiteUrl => "http://testing-ground.scraping.pro/login";

        public static string ChromeDrive => String.Format("{0}{1}", FolderPath, "\\ChromeDriver\\");

        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));

        public static string FolderPicture => String.Format("{0}{1}", FolderPath, "\\ScreenShots\\");
    }
}
