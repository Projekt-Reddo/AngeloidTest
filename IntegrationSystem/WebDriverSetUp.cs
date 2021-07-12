using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AngeloidTest.IntegrationSystem
{
    public class WebDriverSetUp
    {
        protected IWebDriver webDriver;
        protected IJavaScriptExecutor js;

        //Set up web driver
        public void Setup(String browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    //set up chrome web driver
                    webDriver = new ChromeDriver();
                    break;
                case "firefox":
                    //set up firefox web driver
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    throw new Exception("Does not support web browser");
            }

            //JavaScript setup
            js = (IJavaScriptExecutor)webDriver;

            //Every line waiting for appear object in 10s
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        protected void TearDown()
        {
            //Close web driver object
            webDriver.Quit();
        }

        //Test browser list
        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = {
                "chrome", "firefox"
            };

            foreach (string item in browsers)
            {
                yield return item;
            }
        }
    }
}