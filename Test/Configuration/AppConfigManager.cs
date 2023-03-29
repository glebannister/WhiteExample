using System.Configuration;

namespace Test.Configuration
{
    internal static class AppConfigManager
    {
        public static readonly string ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
    }
}
