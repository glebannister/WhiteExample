namespace Test.Utils
{
    internal static class FileUtils
    {
        private const string ResourcesFolder = "Resources";

        public static string GetApplicationExePath(string exeName) 
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(path, ResourcesFolder, exeName);
        }
    }
}
