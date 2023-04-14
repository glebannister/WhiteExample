using System.Diagnostics;

namespace Framework.Utils
{
    internal static class ProcessUtils
    {
        public static IEnumerable<Process> GetProcessesByName(string processName) 
        {
            var processCollection = Process.GetProcesses();
            return processCollection.Where(process => process.ProcessName == processName);
        }
    }
}
