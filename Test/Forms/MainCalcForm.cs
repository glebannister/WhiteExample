using Framework.ApplicationWrapper;
using Framework.Elements;
using Framework.Form;
using Framework.WindowElement;
using System.Windows.Automation;
using Test.Constants;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Test.Forms
{
    internal class MainCalcForm : BaseForm
    {
        private WFButton _oneButton => new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("131")), "OneButton");
        private WFTextView _resultSumTextView => new WFTextView(formWindow.GetElement(SearchCriteria.ByAutomationId("158")), "ResultSumTextView");
        private WFMenuBar _orientationMebuBar => new WFMenuBar(formWindow.GetMenuBar(SearchCriteria
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
            _oneButton.Click();
        }

        public string GetResultSum() 
        {
            return _resultSumTextView.GetText();
        }

        public void ChooseOrientation(params string[] orientation) 
        {
            _orientationMebuBar.ChooseMenuBarItemByPath(orientation);
        }
    }
}
