using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AngeloidTest.IntegrationSystem;
using Angeloid.Models;
using OpenQA.Selenium.Interactions;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class DeleteAnimeTest : WebDriverSetUp
    {
        [Test]
        public void DeleteAnimeCancel([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login 
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("dbdbd9");
            webDriver.FindElement(By.Id("password")).Click();
            webDriver.FindElement(By.Id("password")).SendKeys("admin");
            webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);

            //Go to Setting page
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Go to Admin page
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            {
                var element = webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }

            //Go to Anime Manage page
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();
            {
                var element = webDriver.FindElement(By.TagName("body"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element, 0, 0).Perform();
            }

            //Click "Delete" button in an anime
            webDriver.FindElement(By.CssSelector("tr:nth-child(1) .btn-danger")).Click();
            {
                var element = webDriver.FindElement(By.CssSelector("tr:nth-child(1) .btn-danger"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }

            //Click "Close" button on pop up confirm
            {
                var element = webDriver.FindElement(By.TagName("body"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            webDriver.FindElement(By.CssSelector(".modal-footer > .btn-warning")).Click();
        }


        [Test]
        public void DeleteAnimeConfirm([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Login 
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("dbdbd9");
            webDriver.FindElement(By.Id("password")).Click();
            webDriver.FindElement(By.Id("password")).SendKeys("admin");
            webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);

            //Go to Setting page
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Go to Admin page
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            {
                var element = webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }

            //Go to Anime Manage page
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();
            {
                var element = webDriver.FindElement(By.TagName("body"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element, 0, 0).Perform();
            }

            //Click "Delete" button in an anime
            webDriver.FindElement(By.CssSelector("tr:nth-child(1) .btn-danger")).Click();
            {
                var element = webDriver.FindElement(By.CssSelector("tr:nth-child(1) .btn-danger"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }

            //Click "Delete" button on pop up confirm
            {
                var element = webDriver.FindElement(By.TagName("body"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            webDriver.FindElement(By.CssSelector(".btn-danger:nth-child(2)")).Click();
        }
    }
}