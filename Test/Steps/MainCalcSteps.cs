using NUnit.Framework;
using TechTalk.SpecFlow;
using Test.Forms;

namespace Test.Steps
{
    [Binding]
    public class MainCalcSteps
    {
        private readonly MainCalcForm mainCalcForm = new MainCalcForm();

        [Given(@"Main form is open")]
        public void CheckThatMainFormIsPresent() 
        {
            bool isFormVisible = mainCalcForm.IsFormVisible();
            Assert.IsTrue(isFormVisible, $"Form {mainCalcForm.FormName} isn't visible");
        }

        [When(@"Click on numbers \""(.*)\""")]
        public void clickOnNumber(String splitedNumbers)
        {
            string[] numbers = splitedNumbers.Split(new char[] {' '}, StringSplitOptions.None);
            foreach (String number in numbers)
            {
                mainCalcForm.ClickOnNumber(number);
            }
           
        }

        [Then(@"the result of math should be \""(.*)\""")]
        public void checkMathResult(String expectedResult)
        {
            var amount = mainCalcForm.GetResultSum();
            Assert.AreEqual(amount, expectedResult, $"The total result isn't correct");
        }

        [When(@"Select option (.*) from (.*) menu bar")]
        public void selectOrientation(String option, String menuBar)
        {
            mainCalcForm.ChooseOptionFromMenuBar(option, menuBar);
        }

        [When(@"Add result to memory")]
        public void clickOnMPlus()
        {
            mainCalcForm.ClickOnMPlus();
        }

        [When(@"Get saved result")]
        public void clickOnMR()
        {
            mainCalcForm.ClickOnMR();
        }

        [When(@"Click Plus")]
        public void clickOnPlus()
        {
            mainCalcForm.ClickOnPlus();
        }

        [Then(@"Click on equals")]
        public void clickOnEqual()
        {
            mainCalcForm.ClickOnEquals();
        }
    }
}