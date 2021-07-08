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
    public class RegistrationTest : WebDriverSetUp
    {
        [Test]
        public void RegistrationTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            if (browser.CompareTo("chrome") == 0)
            {
                Setup(browser);
                webDriver.Navigate().GoToUrl("http://localhost:3000/");
                webDriver.Manage().Window.Size = new System.Drawing.Size(1054, 808);
                webDriver.FindElement(By.LinkText("Sign Up")).Click();
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).SendKeys("Test1");
                webDriver.FindElement(By.Id("email")).SendKeys("test1@gmail.com");
                webDriver.FindElement(By.Id("password")).SendKeys("admin");
                webDriver.FindElement(By.Id("repassword")).SendKeys("admin");
                webDriver.FindElement(By.Id("repassword")).SendKeys(Keys.Enter);
                
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).SendKeys("Test1");
                webDriver.FindElement(By.Id("password")).SendKeys("admin");
                webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
                webDriver.FindElement(By.LinkText("Logout")).Click();
            }
            else
            {
                Setup(browser);
                webDriver.Navigate().GoToUrl("http://localhost:3000/");
                webDriver.Manage().Window.Size = new System.Drawing.Size(1054, 808);
                webDriver.FindElement(By.LinkText("Sign Up")).Click();
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).SendKeys("Test2");
                webDriver.FindElement(By.Id("email")).SendKeys("test2@gmail.com");
                webDriver.FindElement(By.Id("password")).SendKeys("admin");
                webDriver.FindElement(By.Id("repassword")).SendKeys("admin");
                webDriver.FindElement(By.Id("repassword")).SendKeys(Keys.Enter);
                
                webDriver.FindElement(By.Id("username")).Click();
                webDriver.FindElement(By.Id("username")).SendKeys("Test2");
                webDriver.FindElement(By.Id("password")).SendKeys("admin");
                webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
                webDriver.FindElement(By.LinkText("Logout")).Click();
            }

        }
    }
}
