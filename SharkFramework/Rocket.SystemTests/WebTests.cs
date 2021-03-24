using NUnit.Framework;
using OpenQA.Selenium;
using Shark.Web.Infrastructure;
using DriverService = Shark.Web.Infrastructure.DriverService;


namespace Rocket.SystemTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DriverService.Start(BrowserType.Chrome);
            
            DriverService.Quit();
        }
    }
}