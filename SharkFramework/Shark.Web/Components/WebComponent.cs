using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Shark.Configuration;
using Shark.Web.Helpers;
using DriverService = Shark.Web.Infrastructure.DriverService;

namespace Shark.Web.Components
{
    public class WebComponent
    {
        private readonly List<Action> _waitActions = new List<Action>();

        public WebComponent()
        {
        }

        public WebComponent(By sourceLocator)
        {
            SourceLocator = sourceLocator;
        }

        public TComponent Create<TComponent>(By locator)
            where TComponent : WebComponent
        {
           TComponent newComponent = Activator.CreateInstance<TComponent>();
           newComponent.SourceLocator = locator;
           newComponent.ParentElement = SourceElement;

           return newComponent;
        }

        public TComponent CreateById<TComponent>(string id)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.Id(id));
        }

        public TComponent CreateByXpath<TComponent>(string xpath)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.XPath(xpath));
        }

        public TComponent CreateByTag<TComponent>(string tag)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.TagName(tag));
        }

        public TComponent CreateByClass<TComponent>(string className)
            where TComponent : WebComponent
        {
            return Create<TComponent>(By.ClassName(className));
        }

        public TComponent CreateByClassContains<TComponent>(string classText)
            where TComponent : WebComponent
        {
            return CreateByXpath<TComponent>($"//*[contains(@class, '{classText}')]");
        }

        public TComponent CreateByIdContains<TComponent>(string id)
            where TComponent : WebComponent
        {
            return CreateByXpath<TComponent>($"//*[contains(@id, '{id}')]");
        }

        public void AddWaitAction(Action action)
        {
            _waitActions.Add(action);
        }

        public By SourceLocator { get; set; }

        public IWebElement SourceElement
        {
            get
            {
                if (!_waitActions.Any())
                {
                    this.ToExist();
                }

                foreach (var act in _waitActions)
                {
                    act.Invoke();
                }

                if (ParentElement != null)
                {
                    return ParentElement.FindElement(SourceLocator);
                }
                else
                {
                    return DriverService.WrappedDriver.Value.FindElement(SourceLocator);
                }
            }
        }

        public IWebElement ParentElement { get; set; }

        public bool IsVisible => SourceElement.Displayed;
    }
}
