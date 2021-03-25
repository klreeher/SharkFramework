using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shark.Configuration;

namespace Shark.Web
{
    public static class WebSettingsConfigurationExtensions
    {
        public static WebSettings GetWebSettings(this ConfigurationService configurationService)
        {
            return configurationService.Root.GetSection("webSettings").Get<WebSettings>();
        }

        public static TimeoutSettings GetTimeoutSettings(this ConfigurationService configurationService)
        {
            return configurationService.Root.GetSection("timeoutSettings").Get<TimeoutSettings>();
        }
    }
}
