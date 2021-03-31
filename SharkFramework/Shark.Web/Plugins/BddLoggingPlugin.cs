using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shark.Web.Components;
using Shark.Web.Services;

namespace Shark.Web.Plugins
{
    public static class BddLoggingPlugin
    {
        public static void Enable()
        {
            if (Configuration.ConfigurationService.Instance.GetWebSettings().BddLogging)
            {
                Anchor.BeforeClick += (o, s) => Logger.Info($"Click on Anchor [{s}].");
                NavigationService.BeforeGoTo += (o, s) => Logger.Info($"Navigating to [{s}].");
            }
        }
    }
}
