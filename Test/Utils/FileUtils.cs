namespace Test.Utils
{
    internal static class FileUtils
    {
        private const string ResourcesFolder = "Resources";

        public static string GetApplicationExePath(string exeName) 
        {
            var projectDirectory = Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName)
                .FullName;
            return Path.Combine(projectDirectory, ResourcesFolder, exeName);
        }
    }
}
