using TestStack.White;

namespace Framework.ApplicationWrapper.Singletons
{
    /// <summary>
    /// Not static singleton
    /// </summary>
    internal class ApplicationInstanceV2
    {
        public readonly Application? _app;

        private static ApplicationInstanceV2? _applicationInstance = null;

        private static object _syncRoot = new();

        private ApplicationInstanceV2()
        {
            _app = Application.Launch("");
        }

        public static ApplicationInstanceV2 GetInstance()
        {
            if (_applicationInstance == null)
            {
                lock (_syncRoot)
                {
                    if (_applicationInstance == null)
                    {
                        _applicationInstance = new ApplicationInstanceV2();
                    }
                }
            }
            return _applicationInstance;
        }

        public void CloseTheApplication()
        {
            KillTheApplicationProcess();
            _applicationInstance = null;
        }

        private void KillTheApplicationProcess()
        {
            if (_app == null) throw new NullReferenceException("The Application has been killed already");
            while (_app.HasExited)
            {
                _app.Kill();
            }
        }
    }
}
