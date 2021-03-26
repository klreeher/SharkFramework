using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web.Components
{
    public class Button : WebComponent
    {
        public Button()
        {
        }

        public Button(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator, sourceElement)
        {
        }

        public int Width => SourceElement.Size.Width;
        public int Height => SourceElement.Size.Height;
        public string Text => SourceElement.Text;

        public void Click() => SourceElement.Click();
    }
}
