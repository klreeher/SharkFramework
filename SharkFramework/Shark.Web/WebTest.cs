using System;
using NUnit.Framework;
using Shark.Web.Infrastructure;
using Shark.Web.Services;

namespace Shark.Web
{
    public class WebTest
    {
        public BrowserService Browser => new BrowserService();
        public NavigationService Navigation => new NavigationService();
        public ComponentService Component => new ComponentService();

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
