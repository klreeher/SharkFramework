using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V85.Network;
using Shark.Web.Services;

namespace Shark.Web.Pages
{
    public abstract class WebPage<TMap, TAssert>
        where TMap : class, new()
        where TAssert : class, new()
    {
        protected readonly ComponentService ComponentService;
        protected readonly NavigationService NavigationService;
        protected readonly BrowserService BrowserService;

        protected WebPage()
        {
            ComponentService = new ComponentService();
            NavigationService = new NavigationService();
            BrowserService = new BrowserService();
        }

        public TMap Map => new TMap();
        public TAssert Assertions => new TAssert();

        public string Title => BrowserService.Title;

        public abstract string Url { get; }

        public void Open()
        {
            NavigationService.GoTo(Url);
        }
    }
}
