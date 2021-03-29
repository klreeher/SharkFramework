using System;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework;
using Shark.Configuration;
using Shark.Web.Helpers;
using Shark.Web.Infrastructure;
using Shark.Web.Services;
using TestStatus = NUnit.Framework.Interfaces.TestStatus;

namespace Shark.Web
{
    public class WebTest
    {
        public BrowserService Browser => new BrowserService();
        public NavigationService Navigation => new NavigationService();
        public ComponentService Component => new ComponentService();
        public ConfigurationService Configuration => ConfigurationService.Instance;

        [OneTimeSetUp]
        public void Setup()
        {
            DriverService.Quit();
            DriverService.Start();
        }

        [TearDown]
        public void TestTeardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                ScreenshotEngine.SaveScreenshot();
                DriverService.Quit();
                DriverService.Start();
            }

            DriverService.ClearCookies();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DriverService.Quit();
        }
    }
}
