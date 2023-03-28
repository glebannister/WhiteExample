using Framework.ApplicationWrapper;
using Framework.Elements;
using Framework.Form;
using Framework.WindowElement;
using TestStack.White.UIItems.Finders;

namespace Test.Forms
{
    internal class MainCalcForm : BaseForm
    {
        private WFButton _oneButton => new WFButton(formWindow.GetUIItem(SearchCriteria.ByAutomationId("131")), "One");

        public MainCalcForm() :
            base(new WFWindow(WFApplication.GetInstance().GetWindowByName("Calculator")), "Calculator main form")
        {
        }

        public void ClickOnOne() 
        {
            _oneButton.Click();
        }
    }
}
