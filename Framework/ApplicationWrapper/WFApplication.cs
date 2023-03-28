using Framework.Utils;
using Framework.Waits;
using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Framework.ApplicationWrapper
{
    public class WFApplication
    {
        public string AppplicationProcessName { get; private set; }

        public Application App { get; private set; }

        private static WFApplication? _applicationInstance = null;

        private static object _syncRoot = new();

        private WFApplication()
        {
        }

        public static WFApplication GetInstance()
        {
            if (_applicationInstance == null)
            {
                lock (_syncRoot)
                {
                    if (_applicationInstance == null)
                    {
                        _applicationInstance = new WFApplication();
                    }
                }
            }
            return _applicationInstance;
        }

        public void Launch(string applicationPath) 
        {
            GetInstance().App = Application.Launch(applicationPath);
            AppplicationProcessName = App.Name;
        }

        public Window GetWindowByName(string windowName) 
        {
            return GetInstance().App.GetWindows().First(window => window.Name.Equals(windowName));
        }

        public Process GetApplicationProcess() 
        {
            return GetInstance().App.Process;
        }

        public void CloseTheApplication(int timeOut = 500)
        {
            CloseTheApplicationProcess(timeOut);
            _applicationInstance = null;
        }

        private void CloseTheApplicationProcess(int timeOut)
        {
            if (GetInstance().App == null) throw new NullReferenceException("The Application has been killed already");
            if (GetInstance().App.HasExited) return;
            ExplicitWait.WaitUntil(() =>
            {
                return IsApplicationClosed();
            },
            timeOut);
        }

        private bool IsApplicationClosed() 
        {
            GetInstance().App.Close();
            return !ProcessUtils
                .GetProcessesByName(AppplicationProcessName)
                .Any();
        }
    }
}
