using Framework.Logging;
using TestStack.White.UIItems;

namespace Framework.Elements
{
    public abstract class BaseElement
    {
        public string ElementName { get; }

        protected IUIItem uiItem;

        protected BaseElement(IUIItem uiitem, string elementName)
        {
            ElementName = elementName;
            this.uiItem = uiitem;
        }

        public void Click() 
        {
            FrameworkLogger.Debug($"Clicking on an element [{ElementName}]");
            uiItem.Click();
            FrameworkLogger.Debug($"Click on an element [{ElementName}] was successful");
        }

        public string GetText()
        {
            FrameworkLogger.Debug($"Getting text from an element [{ElementName}]");
            return uiItem.Name;
        }
    }
}
