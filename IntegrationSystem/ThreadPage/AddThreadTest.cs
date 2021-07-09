using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using Angeloid.Models;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class AddThreadTest : WebDriverSetUp
    {
        [Test]
        public void AddThreadFail([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            // Test name: AddThread
            // Step # | name | target | value
            // 1 | open | / | 
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            // 2 | setWindowSize | 1296x696 | 
            webDriver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
            // 3 | click | linkText=Login | 
            webDriver.FindElement(By.LinkText("Login")).Click();
            // 6 | click | id=username | 
            webDriver.FindElement(By.Id("username")).Click();
            // 7 | type | id=username | lolicorn
            webDriver.FindElement(By.Id("username")).SendKeys("lolicorn");
            // 8 | click | id=password | 
            webDriver.FindElement(By.Id("password")).Click();
            // 9 | type | id=password | admin
            webDriver.FindElement(By.Id("password")).SendKeys("admin");
            // 10 | click | css=.btn:nth-child(9) | 
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();
            // 11 | click | linkText=Thread | 
            webDriver.FindElement(By.LinkText("Thread")).Click();
            // 12 | click | css=.btn-success | 
            webDriver.FindElement(By.CssSelector(".btn-success")).Click();
            // 13 | click | css=.btn-warning | 
            webDriver.FindElement(By.CssSelector(".btn-warning")).Click();
            // 14 | click | Logout
            webDriver.FindElement(By.LinkText("Logout")).Click();
            webDriver.Close();
        }


        [Test]
        public void LoginTrue([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            // Test name: AddThreadTrue
            // Step # | name | target | value
            // 1 | open | / | 
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            // 2 | setWindowSize | 1296x696 | 
            webDriver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
            // 3 | click | linkText=Login | 
            webDriver.FindElement(By.LinkText("Login")).Click();
            // 4 | click | id=username | 
            webDriver.FindElement(By.Id("username")).Click();
            // 5 | type | id=username | lolicorn
            webDriver.FindElement(By.Id("username")).SendKeys("lolicorn");
            // 6 | click | id=password | 
            webDriver.FindElement(By.Id("password")).Click();
            // 7 | type | id=password | admin
            webDriver.FindElement(By.Id("password")).SendKeys("admin");
            // 8 | click | css=.btn:nth-child(9) | 
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();
            // 9 | click | linkText=Thread | 
            webDriver.FindElement(By.LinkText("Thread")).Click();
            // 10 | click | name=posting-title | 
            webDriver.FindElement(By.Name("posting-title")).Click();
            // 11 | type | name=posting-title | My Title
            webDriver.FindElement(By.Name("posting-title")).SendKeys("My Title");
            // 12 | click | css=.form-control:nth-child(1) | 
            webDriver.FindElement(By.CssSelector(".form-control:nth-child(1)")).Click();
            // 13 | type | css=.form-control:nth-child(1) | Nothing
            webDriver.FindElement(By.CssSelector(".form-control:nth-child(1)")).SendKeys("Nothing");
            // 14 | click | css=.p-2 > .btn:nth-child(1) | 
            // webDriver.FindElement(By.CssSelector(".p-2 > .btn:nth-child(1)")).Click();
            // 15 | type | css=.justify-content-between > input | C:\fakepath\682378.jpg
            webDriver.FindElement(By.XPath("//*[@id='root']/div/div[2]/div[2]/form[2]/div[3]/input")).SendKeys("C:\\Users\\bapng\\Pictures\\Yuki\\682378.jpg");
            // 16 | click | css=.btn-success | 
            webDriver.FindElement(By.CssSelector(".btn-success")).Click();
            // 17 | click | Logout
            webDriver.FindElement(By.LinkText("Logout")).Click();
            webDriver.Close();
        }
    }
}