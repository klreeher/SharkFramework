using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.Web;
using Shark.Web.Plugins;

namespace Rocket.SystemTests
{
    public class RocketWebTest : WebTest
    {
        protected override void SetUpPlugins()
        {
            BddLoggingPlugin.Enable();
        }
    }
}
