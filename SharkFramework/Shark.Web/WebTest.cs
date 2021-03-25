using NUnit.Framework;
using Shark.Configuration;
using Shark.Web.Infrastructure;
using Shark.Web.Services;
using System;

namespace Shark.Web
{
    public class WebTest
    {
        public BrowserService Browser => new BrowserService();
        public NavigationService Navigation => new NavigationService();
        public ComponentService Component => new ComponentService();
        public ConfigurationService Configuration => ConfigurationService.Instance;

        [SetUp]
        public void Setup()
        {
            DriverService.Start(BrowserType.Chrome);
        }

        [TearDown]
        public void Teardown()
        {
            DriverService.Quit();
        }
    }
}
