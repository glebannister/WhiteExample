using Framework.ApplicationWrapper;
using Framework.Elements;
using Framework.Form;
using Framework.WindowElement;
using Test.Constants;
using TestStack.White.UIItems.Finders;

namespace Test.Forms
{
    internal class MainCalcForm : BaseForm
    {
        private WFButton OneButton => new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("131")), "OneButton");

        private WFTextView ResultSumTextView => new WFTextView(formWindow.GetElement(SearchCriteria.ByAutomationId("158")), "ResultSumTextView");

        private WFMenuBar OrientationMebuBar => new WFMenuBar(formWindow.GetMenuBar(SearchCriteria
            .ByAutomationId("MenuBar")
            .AndByText("Application")),
            "OrientationMenuBar");

        public MainCalcForm() :
            base(new WFWindow(WFApplication.GetInstance().GetWindowByName(WindowConstants.CalculatorMainWindow)),
                "Calculator main form")
        {
        }

        public void ClickOnOne() 
        {
            OneButton.Click();
        }

        public string GetResultSum() 
        {
            return ResultSumTextView.GetText();
        }

        public void ChooseOrientation(params string[] orientation) 
        {
            OrientationMebuBar.ChooseMenuBarItemByPath(orientation);
        }
    }
}
