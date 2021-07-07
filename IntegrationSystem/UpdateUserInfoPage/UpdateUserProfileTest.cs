using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System;
using System.Collections.Generic;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class UpdateUserProfileTest : WebDriverSetUp
    {
        public static string[] UpdateUserProfileForm = new string[] {
            "Phu",
            "Loc"
        };
        
        [Test]
        public void updateUserProfileTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("UpdateUserProfileForm")] string fullname)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login to web
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("hostcode0301");
            webDriver.FindElement(By.Id("password")).SendKeys("12345678");
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            //Goto setting page
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Edit profile
            webDriver.FindElement(By.Id("userFullName")).Clear();
            webDriver.FindElement(By.Id("userFullName")).SendKeys(fullname);
            webDriver.FindElement(By.CssSelector(".ProfileEdit-Button")).Click();

            //Close notify pop up
            webDriver.FindElement(By.CssSelector(".btn-warning")).Click();

            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }
    }
}
