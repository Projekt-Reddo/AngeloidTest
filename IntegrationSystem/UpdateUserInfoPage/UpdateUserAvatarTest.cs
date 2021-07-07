using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class UpdateUserAvatarTest : WebDriverSetUp
    {
        [Test]
        public void UpdateUserAvatarTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to web url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("hostcode0301");
            webDriver.FindElement(By.Id("password")).SendKeys("12345678");
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            //Goto setting
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Update avatar
            var image = @"D:\Images\アナスタシア\73149094_p0.jpg";

            webDriver.FindElement(By.CssSelector("input:nth-child(1)")).SendKeys(image);

            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close windows
            webDriver.Close();
        }
    }
}
