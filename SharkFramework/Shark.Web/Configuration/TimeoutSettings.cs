using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web
{
    public class TimeoutSettings
    {
        public int ElementToExistTimeout { get; init; }
        public int ElementToNotExistTimeout { get; init; }
        public int elementToBeVisibleTimeout { get; init; }
        public int elementNotToBeVisibleTimeout { get; init; }
        public int ElementToBeClickableTimeout { get; init; }

        public int ElementToHaveContentTimeout { get; init; }
        public int PageLoadTimeout { get; init; }
        public int JavascriptTimeout { get; init; }
        public int ValidationTimeout { get; init; }
    }
}
