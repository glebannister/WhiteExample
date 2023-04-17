using System.Diagnostics;

namespace Framework.Utils
{
    internal static class ProcessUtils
    {
        public static IEnumerable<Process> GetProcessesByName(string processName) 
        {
            return Process.GetProcesses().Where(process => process.ProcessName == processName);
        }
    }
}
