using Framework.Utils;
using Framework.Waits;
using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Framework.ApplicationWrapper
{
    public class WFApplication
    {
        public Application App { get; private set; }

        private string _applicationProcessName;
        private static WFApplication? _applicationInstance;
        private static readonly object _syncRoot = new();

        private WFApplication()
        {
        }

        public void Launch(string applicationPath) 
        {
            if (GetInstance().App != null) return;
            GetInstance().App = Application.Launch(applicationPath);
            _applicationProcessName = GetInstance().App.Process.ProcessName;
        }

        public Window GetWindowByName(string windowName) 
        {
            return GetInstance().App.GetWindows().First(window => window.Name.Equals(windowName));
        }

        public void CloseTheApplication(int timeOut = 1000)
        {
            CloseTheApplicationProcess(timeOut);
            _applicationInstance = null;
        }

        public static WFApplication GetInstance()
        {
            if (_applicationInstance != null) return _applicationInstance;
            lock (_syncRoot)
            {
                if (_applicationInstance == null)
                {
                    _applicationInstance = new WFApplication();
                }
            }
            return _applicationInstance;
        }

        private void CloseTheApplicationProcess(int timeOut)
        {
            if (GetInstance().App == null) throw new NullReferenceException("The Application has been closed already");
            if (GetInstance().App.HasExited) return;
            ExplicitWait.WaitUntil(() => IsApplicationClosed(), timeOut);
        }

        private bool IsApplicationClosed() 
        {
            GetInstance().App.Close();
            return !ProcessUtils
                .GetProcessesByName(_applicationProcessName)
                .Any();
        }
    }
}
