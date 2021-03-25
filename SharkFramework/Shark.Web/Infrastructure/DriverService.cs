using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shark.Web.Infrastructure
{
    public class DriverService
    {
        public static ThreadLocal<IWebDriver> WrappedDriver { get; set; }

        static DriverService()
        {
            WrappedDriver = new ThreadLocal<IWebDriver>();
        }

        public static void Quit()
        {
            WrappedDriver.Value.Quit();
            WrappedDriver.Value.Dispose();
        }

        public static void Start(BrowserType browserType)
        {
            IWebDriver driver = default;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Safari:
                    driver = new SafariDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(browserType),
                        browserType,
                        $"{nameof(browserType)} Not Supported");
            }

            WrappedDriver.Value = driver;
        }
    }
}
