using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System;
using System.Collections.Generic;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class ViewAnimeTest : WebDriverSetUp
    {
        public static string[] ViewAnimeTestFormTrue = new string[] {
            "1",
            "2",
            "3"
        };
        
        [Test]
        public void ViewAnimeTestTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("ViewAnimeTestFormTrue")] string id)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login to web
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("thinhnpce");
            webDriver.FindElement(By.Id("password")).SendKeys("123456");
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            // Goto Anime Details
            webDriver.Navigate().GoToUrl("http://localhost:3000/anime/" + id);
            
            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }
        public static string[] ViewAnimeTestFormFalse = new string[] {
            "a",
            "2b",
            "c3q"
        };
        [Test]
        public void ViewAnimeTestTestFalse([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("ViewAnimeTestFormFalse")] string id)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login to web
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("thinhnpce");
            webDriver.FindElement(By.Id("password")).SendKeys("123456");
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            // Goto Anime Details
            webDriver.Navigate().GoToUrl("http://localhost:3000/anime/" + id);
            
            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }        
    }
}
