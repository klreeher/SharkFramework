using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using Shark.Configuration;
using DriverService = Shark.Web.Infrastructure.DriverService;

namespace Shark.Web.Helpers
{
    public static class ScreenshotEngine
    {
        public static void SaveScreenshot()
        {
            if (!ConfigurationService.Instance.GetWebSettings().ScreenshotsOnFailure)
            {
                return;
            }

            var rootLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var saveLocation = Path.Combine(rootLocation, ConfigurationService.Instance.GetWebSettings().DefaultSaveLocation);
            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            string fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.png";
            string absoluteFilePath = Path.Combine(saveLocation, fileName);
            Screenshot image = ((ITakesScreenshot)DriverService.WrappedDriver.Value).GetScreenshot();
            image.SaveAsFile(absoluteFilePath);
            Logger.Error($"Saved Screenshot of Failure at {absoluteFilePath}");
        }
    }
}
