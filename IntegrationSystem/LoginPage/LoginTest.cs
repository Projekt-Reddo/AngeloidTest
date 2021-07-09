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
    public class LoginTest : WebDriverSetUp
    {
        //Test Case for login
        public static List<User> LoginFailedForm = new List<User> {
            new User { UserName = "", Password = "" },
            new User { UserName = "lolicorn", Password = "dbdbd9" },
            new User { UserName = "Khongtontai", Password = "Khongtontai" }
        };


        [Test]
        public void LoginFailed([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("LoginFailedForm")] User loginUser)
        {
            //Create web driver object
            Setup(browser);

            // Test name: LoginTrue
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
            webDriver.FindElement(By.Id("username")).SendKeys(loginUser.UserName);
            // 6 | type | id=password | admin
            webDriver.FindElement(By.Id("password")).SendKeys(loginUser.Password);
            // 7 | sendKeys | id=password | ${KEY_ENTER}
            webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
            webDriver.Close();
        }

        //Test Case for login
        public static List<User> LoginTrueForm = new List<User> {
            new User { UserName = "lolicorn", Password = "admin" },
        };


        [Test]
        [TestCaseSource("LoginTestCase")]
        public void LoginTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("LoginTrueForm")] User loginUser)
        {
            //Create web driver object
            Setup(browser);

            // Test name: LoginTrue
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
            webDriver.FindElement(By.Id("username")).SendKeys(loginUser.UserName);
            // 6 | type | id=password | admin
            webDriver.FindElement(By.Id("password")).SendKeys(loginUser.Password);
            // 7 | sendKeys | id=password | ${KEY_ENTER}
            webDriver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
            // 8 | click | Logout
            webDriver.FindElement(By.LinkText("Logout")).Click();
            webDriver.Close();
        }
    }
}
