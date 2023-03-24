using Framework.Utils;
using Framework.Waits;
using System.Diagnostics;
using TestStack.White;

namespace Framework.ApplicationWrapper
{

    //Singleton
    public class WFApplication
    {
        public string ApplicationPath { get; private set; }

        public string AppplicationProcessName { get; private set; }

        public Application App { get; private set; }

        private static WFApplication? _applicationInstance = null;

        private static object _syncRoot = new();

        private WFApplication(string applicationPath)
        {
            App = Application.Launch(applicationPath);
            ApplicationPath = applicationPath;
            AppplicationProcessName = App.Process.ProcessName;
        }

        public static WFApplication GetInstance(string applicationPath)
        {
            if (_applicationInstance == null)
            {
                lock (_syncRoot)
                {
                    if (_applicationInstance == null)
                    {
                        _applicationInstance = new WFApplication(applicationPath);
                    }
                }
            }
            return _applicationInstance;
        }

        public Process GetApplicationProcess() 
        {
            return GetInstance(ApplicationPath).App.Process;
        }

        public static Application AttachByProcessId(int processId) 
        {
            return Application.Attach(processId);
        }

        public void CloseTheApplication(int timeOut = 500)
        {
            CloseTheApplicationProcess(timeOut);
            _applicationInstance = null;
        }

        private void CloseTheApplicationProcess(int timeOut)
        {
            if (GetInstance(ApplicationPath).App == null) throw new NullReferenceException("The Application has been killed already");
            if (GetInstance(ApplicationPath).App.HasExited) return;
            ExplicitWait.WaitUntil(() =>
            {
                return IsApplicationClosed();
            },
            timeOut);
        }

        private bool IsApplicationClosed() 
        {
            GetInstance(ApplicationPath).App.Close();
            return !ProcessUtils
                .GetProcessesByName(AppplicationProcessName)
                .Any();
        }
    }
}
