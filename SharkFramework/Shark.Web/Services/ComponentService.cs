using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Shark.Web.Components;
using Shark.Web.Infrastructure;
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

        private IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement nativeWebElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            return nativeWebElement;
        }
    }
}
