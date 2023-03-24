using Framework.Log;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Framework.WindowElement
{
    public class WFWindow
    {
        public bool IsVisible => _currentWindow.Visible;

        public string Name => _currentWindow.Name;

        public void WaitWhileBusy() => _currentWindow.WaitWhileBusy();

        public Window GetModalWindow(string modalWindowName) => FindModalWindow(modalWindowName);

        public bool Exists
        {
            get
            {
                try
                {
                    if (_currentWindow.Visible && _currentWindow.Enabled)
                    {
                        FrameworkLogger.Debug($"Window {_currentWindow.Name} exists");
                        return true;
                    }
                    FrameworkLogger.Debug($"Window {_currentWindow.Name} is not exist");
                    return false;
                }
                catch (Exception ex) when (ex is AutomationException
                    || ex is ElementNotAvailableException)
                {
                    FrameworkLogger.Debug($"Window {_currentWindow.Name} is not exist");
                    return false;
                }
            }
        }

        public Window Window
        {
            get
            {
                if (_currentWindow == null)
                {
                    throw new AutomationException("", "");
                }

                return _currentWindow;
            }

            set
            {
                _currentWindow = value;
            }
        }

        private Window _currentWindow;

        public WFWindow(Window window)
        {
            _currentWindow = window;
        }

        private Window FindModalWindow(string modalWindowName)
        {
            FrameworkLogger.Debug($"Finding modal window by name {modalWindowName}");
            return _currentWindow.ModalWindow(modalWindowName);
        }
    }
}
