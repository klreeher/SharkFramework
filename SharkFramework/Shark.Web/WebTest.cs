using System;
using System.Linq;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework;
using Shark.Configuration;
using Shark.Web.Components;
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
        private static readonly ThreadLocal<bool> ArePluginsSubscribed = new ThreadLocal<bool>();

        [SetUp]
        public void TestSetUp()
        {
            if (!ArePluginsSubscribed.Value)
            {
                SetUpPlugins();
                ArePluginsSubscribed.Value = true;
            }

            var requestedBrowserObj = TestContext.CurrentContext.Test.Arguments.FirstOrDefault();
            if (requestedBrowserObj != null && requestedBrowserObj is BrowserType requestedBrowserType)
            {
                if (requestedBrowserType != DriverService.PreviousBrowserType.Value)
                {
                    DriverService.Quit();
                    DriverService.Start(requestedBrowserType);
                }
            }
            else
            {
                DriverService.Quit();
                DriverService.Start();
            }
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

        protected virtual void SetUpPlugins()
        {
        }
    }
}
