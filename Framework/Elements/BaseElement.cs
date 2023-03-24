using Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace Framework.Elements
{
    public abstract class BaseElement
    {
        public string _customName;

        protected UIItem _uIItem;

        protected BaseElement(UIItem uIItem, string customName) 
        {
            _uIItem = uIItem;
            _customName = customName;
        }

        public void Click() 
        {
            FrameworkLogger.Debug($"Clicking on an element [{_customName}]");
            _uIItem.Click();
            FrameworkLogger.Debug($"Click on an element [{_customName}] was successful");
        }
    }
}
