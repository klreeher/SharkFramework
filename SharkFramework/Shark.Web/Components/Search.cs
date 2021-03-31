using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.Web.Components
{
    public class Search : WebComponent
    {
        public Search()
        {
        }

        public Search(By sourceLocator, IWebElement sourceElement)
            : base(sourceLocator)
        {
        }

        public void SearchFor(string searchText)
        {
            SourceElement.Clear();
            SourceElement.SendKeys(searchText);
            SourceElement.SendKeys(Keys.Return);
        }

        public string PlaceholderText => SourceElement.GetAttribute("placeholder");
    }
}
