using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web.Components
{
    public class WebComponent
    {
        public WebComponent()
        {
        }

        public WebComponent(By sourceLocator, IWebElement sourceElement)
        {
            SourceElement = sourceElement;
            SourceLocator = sourceLocator;
        }

        public By SourceLocator { get; set; }
        public IWebElement SourceElement { get; set; }
    }
}
