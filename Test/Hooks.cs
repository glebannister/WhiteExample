using Framework.ApplicationWrapper;
using TechTalk.SpecFlow;
using Test.Configuration;
using Test.Utils;

namespace Test
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void Setup()
        {
            var path = FileUtils.GetApplicationExePath(AppConfigManager.ApplicationName);
            WFApplication.GetInstance().Launch(path);
        }

        [AfterScenario]
        public void TearDonw()
        {
            WFApplication.GetInstance().CloseTheApplication();
        }
    }
}