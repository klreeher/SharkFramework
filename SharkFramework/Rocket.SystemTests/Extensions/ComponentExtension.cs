using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Shark.Web.Components;

namespace Rocket.SystemTests
{
    public static class ComponentExtension
    {
        public static TComponent CreateByIdEndingWith<TComponent>(this TComponent component, string suffix)
            where TComponent : WebComponent
        {
            return component.CreateByXpath<TComponent>($"//*[ends-with(@id,'{suffix}')]");
        }
    }
}
