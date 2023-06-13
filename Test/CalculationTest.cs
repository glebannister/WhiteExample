using Framework.ApplicationWrapper;
using NUnit.Framework;
using Test.Configuration;
using Test.Forms;
using Test.Utils;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var path = FileUtils.GetApplicationExePath(AppConfigManager.ApplicationName);
            WFApplication.GetInstance().Launch(path);
        }

        [Test]
        public void ClickOneButtonTest()
        {
            MainCalcForm mainCalcForm = new MainCalcForm();
            bool isFormVisible = mainCalcForm.IsFormVisible();
            Assert.IsTrue(isFormVisible, $"Form {mainCalcForm.FormName} isn't visible");
            mainCalcForm.ClickOnOne();
            var amount = mainCalcForm.GetResultSum();
            Assert.AreEqual(amount, "1", $"The total sum isn't correct");
        }

        [TearDown]
        public void TearDonw() 
        {
            WFApplication.GetInstance().CloseTheApplication();
        }
    }
}