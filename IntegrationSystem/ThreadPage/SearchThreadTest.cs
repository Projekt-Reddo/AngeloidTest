using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System;
using System.Collections.Generic;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class SearchThreadTest : WebDriverSetUp
    {
        public static string[] SearchThreadForm = new string[] {
            "Phu",
            "Loc"
        };

        [Test]
        public void SearchThreadTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("SearchThreadForm")] string fullname)
        {
            Setup(browser);
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            webDriver.FindElement(By.LinkText("Thread")).Click();
            webDriver.FindElement(By.CssSelector(".form-control")).Click();
            webDriver.FindElement(By.CssSelector(".form-control")).SendKeys("Thread 1");
            webDriver.FindElement(By.CssSelector(".form-control")).SendKeys(Keys.Enter);
        }
    }
}
