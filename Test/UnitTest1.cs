using Framework.ApplicationWrapper;
using NUnit.Framework;
using System.Configuration;

namespace Test
{
    public class Tests
    {
        private string tempPath = @"C:\Users\g.ignatovich\Desktop\akvaTxt\ExpertsService\DesctopAutomation\CodeExamples\MasterClass\WhiteExample\Test\Resources\calc.exe";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                Constants.ApplicationName);
            var application = WFApplication.GetInstance(tempPath).GetApplicationProcess();
            WFApplication.GetInstance(path).CloseTheApplication();
        }
    }
}