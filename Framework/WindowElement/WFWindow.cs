using Framework.Logging;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Framework.WindowElement
{
    public class WFWindow
    {
        public bool IsVisible => _currentWindow.Visible;

        public string Name => _currentWindow.Name;

        public Window Window => _currentWindow ?? throw new AutomationException("", "");

        private Window _currentWindow;

        public WFWindow(Window window)
        {
            _currentWindow = window;
        }

        public bool IsExist()
        {
            try
            {
                var isExist = _currentWindow.Visible && _currentWindow.Enabled;
                FrameworkLogger.Debug($"Window {_currentWindow.Name} {(isExist ? "exists" : "is not exis")}");
                return isExist;
            }
            catch (Exception ex) when (ex is AutomationException
                    || ex is ElementNotAvailableException)
            {
                FrameworkLogger.Debug($"Window {_currentWindow.Name} is not exist");
                return false;
            }
        }

        public void WaitWhileBusy() => _currentWindow.WaitWhileBusy();

        public Window GetModalWindow(string modalWindowName) => FindModalWindow(modalWindowName);

        public IUIItem GetUIItem(SearchCriteria searchCriteria) => FindElement(searchCriteria);

        private IUIItem FindElement(SearchCriteria searchCriteria) 
        {
            FrameworkLogger.Debug($"Finding element by searchCriteria {searchCriteria}");
            return _currentWindow.Get(searchCriteria);
        }

        private Window FindModalWindow(string modalWindowName)
        {
            FrameworkLogger.Debug($"Finding modal window by name {modalWindowName}");
            return _currentWindow.ModalWindow(modalWindowName);
        }
    }
}
