using TestStack.White;

namespace Framework.ApplicationWrapper.Singletons
{
    public static class ApplicationInstance
    {
        private static Application? _app;

        private static object _syncRoot = new();

        public static Application GetInstance()
        {
            lock (_syncRoot)
            {
                if (_app == null)
                {
                    _app = Application.Launch("");
                }
            }
            return _app;
        }

        public static string Name()
        {
            return GetInstance().Name;
        }

        public static void CloseTheApplication()
        {
            KillTheApplicationProcess();
            _app = null;
        }

        private static void KillTheApplicationProcess()
        {
            if (_app == null) throw new NullReferenceException("The Application has been killed already");
            while (_app.HasExited)
            {
                _app.Kill();
            }
        }
    }
}
