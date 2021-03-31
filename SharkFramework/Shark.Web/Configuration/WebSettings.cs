using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web
{
    public class WebSettings
    {
        public string DefaultBrowser { get; init; }
        public string DefaultSaveLocation { get; init; }
        public bool ScreenshotsOnFailure { get; init; }
        public bool BddLogging { get; init; }
    }
}
