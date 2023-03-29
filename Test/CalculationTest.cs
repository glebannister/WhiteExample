using Framework.ApplicationWrapper;
using Framework.WindowElement;
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
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDonw() 
        {
            WFApplication.GetInstance().CloseTheApplication();
        }
    }
}