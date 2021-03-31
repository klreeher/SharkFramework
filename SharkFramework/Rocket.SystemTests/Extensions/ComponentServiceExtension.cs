using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.Web.Components;
using Shark.Web.Services;

namespace Rocket.SystemTests
{
    public static class ComponentServiceExtension
    {
        public static TComponent CreateByIdEndsWith<TComponent>(this ComponentService service, string suffix)
            where TComponent : WebComponent
        {
            return service.CreateByXpath<TComponent>($"//*[contains(@id, '{suffix}')]");
        }
    }
}
