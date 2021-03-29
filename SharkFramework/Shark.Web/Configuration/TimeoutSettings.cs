using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web
{
    public class TimeoutSettings
    {
        public int WaitForElementTimeout { get; init; }
        public int PageLoadTimeout { get; init; }
        public int JavascriptTimeout { get; init; }
    }
}
