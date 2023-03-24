using Framework.Log;
using Framework.WindowElement;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Framework.Form
{
    public abstract class BaseForm
    {
        private WFWindow _formWindow;

        private string _formName;

        protected BaseForm(WFWindow formWindow, string formName) 
        {
            _formWindow = formWindow;
            _formName = formName;
        }

        public T GetElement<T>(SearchCriteria searchCriteria, string elementName) where T : IUIItem
        {
            FrameworkLogger.Info($"Creating element [Type:'{typeof(T)}', Elements' name:'{elementName}' Forms' name:'{_formName}']");
            return _formWindow.Window.Get<T>(searchCriteria);
        }
    }
}
