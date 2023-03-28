using Framework.Log;
using TestStack.White.UIItems;

namespace Framework.Elements
{
    public abstract class BaseElement
    {
        public string ElementName { get; }

        protected IUIItem UiItem;

        protected BaseElement(IUIItem uiitem, string elementName)
        {
            ElementName = elementName;
            UiItem = uiitem;
        }

        public void Click() 
        {
            FrameworkLogger.Debug($"Clicking on an element [{ElementName}]");
            UiItem.Click();
            FrameworkLogger.Debug($"Click on an element [{ElementName}] was successful");
        }
    }
}
