using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V85.DOM;
using Shark.Configuration;
using Shark.Web.Infrastructure;

namespace Shark.Web.Services
{
    public class BrowserService
    {
        public void Back()
        {
            ////int elementTimeout = ConfigurationService.Instance.GetTimeoutSettings().WaitForElementTimeout;
            DriverService.WrappedDriver.Value.Navigate().Back();
        }

        public void Forward()
        {
            DriverService.WrappedDriver.Value.Navigate().Forward();
        }

        public void Refresh()
        {
            DriverService.WrappedDriver.Value.Navigate().Refresh();
        }

        public string Title => DriverService.WrappedDriver.Value.Title;
    }
}
