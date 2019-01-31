using SeleniumTestsNetCore.Config;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeleniumTestsNetCore.AutomatedTests
{
    public class SiteTest
    {
        public SeleniumHelper Browser;

        public SiteTest()
        {
            // Arrange
            Browser = SeleniumHelper.Instance();
        }

        [Fact]
        public void LoginSuccess()
        {
            // Act
            Browser.NavigateToUrl(ConfigurationHelper.SiteUrl);
            Browser.WriteInTexboxById("usr", "admin");
            Browser.WriteInTexboxById("pwd", "12345");
            Browser.LinkClickByXPath("//*[@id=\"case_login\"]/form/input[3]");
            var result = Browser.GetElementTextByClass("success");

            // Assert
            Assert.Contains("welcome", result.ToLower());
        }

        [Fact]
        public void LoginFailed()
        {
            // Act
            Browser.NavigateToUrl(ConfigurationHelper.SiteUrl);
            Browser.WriteInTexboxById("usr", "test");
            Browser.WriteInTexboxById("pwd", "12345");
            Browser.LinkClickByXPath("//*[@id=\"case_login\"]/form/input[3]");
            var result = Browser.GetElementTextByClass("error");

            // Assert
            Assert.Contains("access denied", result.ToLower());
        }
    }
}
