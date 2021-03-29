using ICSharpCode.SharpZipLib.Zip;
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
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Shark.Web.Infrastructure
{
    public class DriverService
    {
        public static ThreadLocal<IWebDriver> WrappedDriver { get; set; }

        static DriverService()
        {
            WrappedDriver = new ThreadLocal<IWebDriver>();
        }

        private static BrowserType ParseBrowserTypeFromString(string browserName)
        {
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browserName, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void Quit()
        {
            WrappedDriver.Value?.Quit();
            WrappedDriver.Value?.Dispose();
        }

        public static void ClearCookies()
        {
            WrappedDriver.Value.Manage().Cookies.DeleteAllCookies();
        }

        public static void Start()
        {
            string browserName = Configuration.ConfigurationService.Instance.GetWebSettings().DefaultBrowser;
            var defaultBrowser = ParseBrowserTypeFromString(browserName);
            Start(defaultBrowser);
        }

        public static void Start(BrowserType browserType)
        {
            IWebDriver driver = default;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
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
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Configuration.ConfigurationService.Instance.GetTimeoutSettings().PageLoadTimeout);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(Configuration.ConfigurationService.Instance.GetTimeoutSettings().JavascriptTimeout);
        }
    }
}
