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
    public class DeleteThreadTest : WebDriverSetUp
    {
        [Test]
        public void DeleteThreadTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            Setup(browser);
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            webDriver.Manage().Window.Size = new System.Drawing.Size(1054, 808);
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("BaoLoc");
            webDriver.FindElement(By.Id("password")).SendKeys("admin");
            webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
            {
                var element = webDriver.FindElement(By.CssSelector(".col-6:nth-child(3) > a > div:nth-child(1)"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            webDriver.FindElement(By.CssSelector(".fa-chevron-right")).Click();
            webDriver.FindElement(By.CssSelector("tr:nth-child(2) .btn")).Click();
            webDriver.FindElement(By.CssSelector(".btn-danger:nth-child(2)")).Click();
            webDriver.FindElement(By.CssSelector(".page-item:nth-child(2) > .page-link")).Click();
            {
                var element = webDriver.FindElement(By.CssSelector(".page-item:nth-child(2) > .page-link"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).ClickAndHold().Perform();
            }
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
