using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Shark.Web.Components
{
    public class Image : WebComponent
    {
        public Image()
        {
        }

        public Image(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator, sourceElement)
        {
        }

        public int Width => SourceElement.Size.Width;
        public int Height => SourceElement.Size.Height;

        public string Src => SourceElement.GetAttribute("src");
        public string Href => SourceElement.GetAttribute("href");
    }
}
