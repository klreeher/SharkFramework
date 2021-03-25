using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.Web.Infrastructure;

namespace Shark.Web.Services
{
    public class NavigationService
    {
        public void GoTo(string url)
        {
            DriverService.WrappedDriver.Value.Navigate().GoToUrl(url);
        }
    }
}
