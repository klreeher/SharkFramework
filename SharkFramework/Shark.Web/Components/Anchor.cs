using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Shark.Web.Components
{
    public class Anchor : WebComponent
    {
        public Anchor()
        {
        }

        public Anchor(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator, sourceElement)
        {
        }

        public string Href => SourceElement.GetAttribute("href");
    }
}
