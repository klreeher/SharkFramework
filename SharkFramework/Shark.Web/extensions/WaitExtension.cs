using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shark.Configuration;
using Shark.Web.Components;
using Shark.Web.Infrastructure;

namespace Shark.Web
{
    public static class WaitExtension
    {
        public static TComponent ToExist<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            var elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToExistTimeout;
            var wait = new WebDriverWait(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementExists(component.SourceLocator)));
            return component;
        }

        public static TComponent ToBeVisible<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            var elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().elementToBeVisibleTimeout;
            var wait = new WebDriverWait(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementIsVisible(component.SourceLocator)));
            return component;
        }

        public static TComponent ToBeClickable<TComponent>(this TComponent component)
            where TComponent : WebComponent
        {
            var elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ElementToBeClickableTimeout;
            var wait = new WebDriverWait(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            component.AddWaitAction(() => wait.Until(ExpectedConditions.ElementToBeClickable(component.SourceLocator)));
            return component;
        }
    }
}
