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

        public void ClickOnNumber(String number) 
        {
            new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId($"13{number}")), $"{number} Button").Click();
        }

        public string GetResultSum() 
        {
            return _resultSumTextView.GetText();
        }

        public void ChooseOptionFromMenuBar(String option, String menuBar) 
        {
            _orientationMebuBar.ClickChildMenuItem(menuBar);
            new WFButton(formWindow.GetElement(SearchCriteria.ByText(option)), $"{option} Button").Click();
        }

        public void ClickOnMPlus()
        {
            new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("125")), "M+ Button").Click();
        }

        public void ClickOnMR()
        {
            new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("123")), "MR Button").Click();
        }

        public void ClickOnPlus()
        {
            new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("93")), "Plus Button").Click();
        }

        public void ClickOnEquals()
        {
            new WFButton(formWindow.GetElement(SearchCriteria.ByAutomationId("121")), "MR Button").Click();
        }
    }
}