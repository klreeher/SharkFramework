using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.Web.Services;

namespace Shark.Web.Pages
{
    public abstract class WebAssertions<TMap>
        where TMap : WebMap, new()
    {
        protected readonly ComponentService ComponentService;
        protected TMap Map => new TMap();
        protected WebAssertions()
        {
            ComponentService = new ComponentService();
        }
    }
}
