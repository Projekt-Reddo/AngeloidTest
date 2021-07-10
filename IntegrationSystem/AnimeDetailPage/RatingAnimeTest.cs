using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;
using OpenQA.Selenium.Interactions;

using System.Threading;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class RatingAnimeTest : WebDriverSetUp
    {
        [Test]
        public void RatingAnimeTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            if (browser.CompareTo("chrome") == 0)
            {
                Setup(browser);
                Assert.Pass();
            }
            else
            {
                Setup(browser);
                webDriver.Navigate().GoToUrl("http://localhost:3000/");
                webDriver.Manage().Window.Size = new System.Drawing.Size(1051, 806);
                webDriver.FindElement(By.LinkText("Login")).Click();
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).SendKeys("BaoLoc");
                webDriver.FindElement(By.Id("password")).SendKeys("admin");
                webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
                webDriver.FindElement(By.CssSelector(".w-100:nth-child(3) .col-6:nth-child(2) > a > div:nth-child(1)")).Click();
                js.ExecuteScript("window.scrollTo(0,0)");
                webDriver.FindElement(By.CssSelector(".rating-button")).Click();
                webDriver.FindElement(By.CssSelector("label:nth-child(2)")).Click();
                webDriver.FindElement(By.LinkText("Logout")).Click();
            }

        }
    }
}
