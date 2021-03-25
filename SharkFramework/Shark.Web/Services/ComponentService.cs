using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Shark.Configuration;
using Shark.Web.Components;
using Shark.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverService = Shark.Web.Infrastructure.DriverService;

namespace Shark.Web.Services
{
    public class ComponentService
    {
        public TComponent CreateById<TComponent>(string id)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.Id(id));
        }

        public TComponent CreateByXpath<TComponent>(string xpath)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.XPath(xpath));
        }

        public TComponent CreateByClass<TComponent>(string className)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.ClassName(className));
        }

        public TComponent Create<TComponent>(By locator)
            where TComponent : WebComponent
        {
            var webElement = WaitUntilElementExists(DriverService.WrappedDriver.Value, locator);

            TComponent newComponent = Activator.CreateInstance<TComponent>();
            newComponent.SourceLocator = locator;
            newComponent.SourceElement = webElement;

            return newComponent;
        }

        private IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator)
        {
            int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().WaitForElementTimeout;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(elementTimeout));
            IWebElement nativeWebElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            return nativeWebElement;
        }
    }
}
