using Shark.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web.Services
{
    public class NavigationService
    {
        public static event EventHandler<string> BeforeGoTo;
        public static event EventHandler<string> AfterGoTo;
        public void GoTo(string url)
        {
            BeforeGoTo?.Invoke(this, url);
            DriverService.WrappedDriver.Value.Navigate().GoToUrl(url);
            AfterGoTo?.Invoke(this, url);
        }
    }
}
