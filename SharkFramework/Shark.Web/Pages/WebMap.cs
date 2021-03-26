using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.Web.Services;

namespace Shark.Web.Pages
{
    public abstract class WebMap
    {
        protected readonly ComponentService ComponentService;

        protected WebMap()
        {
            ComponentService = new ComponentService();
        }
    }
}
