using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Shark.Configuration;
using Shark.Web.Components.Interfaces;
using DriverService = Shark.Web.Infrastructure.DriverService;

namespace Shark.Web.Components
{
    public class Image : WebComponent, ISrc
    {
        public Image()
        {
        }

        public Image(By sourceLocator)
            : base(sourceLocator)
        {
        }

        public int Width => SourceElement.Size.Width;
        public int Height => SourceElement.Size.Height;

        public string Src { get; set; }
        public string Href => SourceElement.GetAttribute("href");
    }
}
