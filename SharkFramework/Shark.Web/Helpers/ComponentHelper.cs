using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Shark.Configuration;
using Shark.Web.Infrastructure;

namespace Shark.Web.Helpers
{
    public class ComponentHelper
    {
        public static void WaitUntil(Func<bool> condition)
        {
            var elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().ValidationTimeout;
            var wait = new WebDriverWait(DriverService.WrappedDriver.Value, TimeSpan.FromSeconds(elementTimeout));
            wait.Until(d => condition());
        }
    }
}
