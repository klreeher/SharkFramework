using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shark.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriverService = Shark.Web.Infrastructure.DriverService;

namespace Shark.Web.Components
{
    public class Anchor : WebComponent
    {
        public static event EventHandler<string> BeforeClick;
        public static event EventHandler<string> AfterClick;

        public Anchor()
        {
        }

        public Anchor(By sourceLocator)
            : base(sourceLocator)
        {
        }

        public string Href => SourceElement.GetAttribute("href");

        public void Click()
        {
            BeforeClick?.Invoke(this, SourceLocator.ToString());
            SourceElement.Click();
            AfterClick?.Invoke(this, SourceLocator.ToString());
        }

        public void ValidateHrefIs(string expectedHref)
        {
            Helpers.ComponentHelper.WaitUntil(() => Href.Equals(expectedHref));
        }
    }
}
