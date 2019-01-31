using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestsNetCore.Config
{
    public class SeleniumHelper
    {
        public static IWebDriver ChromeDriver;

        private static SeleniumHelper _instance;

        public OpenQA.Selenium.Support.UI.WebDriverWait Wait;
        public Actions Actions;

        public SeleniumHelper()
        {
            ChromeDriver = new ChromeDriver(ConfigurationHelper.ChromeDrive);
            Wait = new OpenQA.Selenium.Support.UI.WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(30));
            Actions = new Actions(ChromeDriver);
        }

        public static SeleniumHelper Instance()
        {
            return _instance ?? (_instance = new SeleniumHelper());
        }

        public string GetUrl()
        {
            return ChromeDriver.Url;
        }

        public bool ValidadeUrlContent(string content)
        {
            return Wait.Until(ExpectedConditions.UrlContains(content));
        }

        public string NavigateToUrl(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);

            return ChromeDriver.Url;
        }

        public void LinkClickByText(string text)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(text)));
            link.Click();
        }

        public void LinkClickById(string id)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            link.Click();
        }

        public void LinkClickByClass(string className)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
            link.Click();
        }

        public void LinkClickByXPath(string xpath)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            link.Click();
        }

        public void WriteInTexboxById(string id, string value)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            campo.SendKeys(value);
        }

        public void WriteInTexboxByXPath(string xpath, string value)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            campo.SendKeys(value);
        }

        public string GetElementTextById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public string GetElementTextByClass(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public void TakeScreenShot(string name)
        {
            var screenshot = ((ITakesScreenshot)ChromeDriver).GetScreenshot();
            SaveScreenShot(screenshot, string.Format("{0}_{1}.png", DateTime.Now.ToFileTime(), name));
        }

        private static void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile(string.Format("{0}{1}", ConfigurationHelper.FolderPicture, fileName),
                ScreenshotImageFormat.Png);
        }

    }
}
