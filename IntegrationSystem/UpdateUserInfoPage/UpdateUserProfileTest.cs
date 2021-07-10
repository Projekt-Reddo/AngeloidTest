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
        public class InputProfile
        {
            public string fullname { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
        }

        private static readonly InputProfile[] UpdateUserProfileTestCaseTrue = new InputProfile[] {
            new InputProfile {
                fullname = "PhuTT",
                email = "hostcode0301@gmail.com",
                gender = "Male",
            },
            new InputProfile {
                fullname = "",
                email = "hostcode03013@gmail.com",
                gender = "Female",
            },
            new InputProfile {
                fullname = "1234",
                email = "hostcode@gmail.com",
                gender = "None",
            },
            new InputProfile {
                fullname = "",
                email = "hostcode03012@gmail.com",
                gender = "Female",
            },
        };

        [Test]
        public void UpdateUserProfileTestTrue(
            [ValueSourceAttribute("BrowserToRunWith")] string browser,
            [ValueSourceAttribute("UpdateUserProfileTestCaseTrue")] InputProfile inputProfile)
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
            webDriver.FindElement(By.Id("userFullName")).SendKeys(inputProfile.fullname);

            webDriver.FindElement(By.Id("userEmail")).Clear();
            webDriver.FindElement(By.Id("userEmail")).SendKeys(inputProfile.email);

            {
                var dropdown = webDriver.FindElement(By.Id("userGender"));
                dropdown.FindElement(By.XPath($"//option[. = '{inputProfile.gender}']")).Click();
            }

            webDriver.FindElement(By.CssSelector(".ProfileEdit-Button")).Click();

            //Close notify pop up
            webDriver.FindElement(By.CssSelector(".btn-warning")).Click();

            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }

        private static readonly InputProfile[] UpdateUserProfileTestCaseFalse = new InputProfile[] {
            new InputProfile {
                fullname = "PhuTT",
                email = "hostcode0301",
                gender = "Male",
            },
            new InputProfile {
                fullname = "PhuTT",
                email = "",
                gender = "Male",
            }
        };

        [Test]
        public void UpdateUserProfileTestFalse(
            [ValueSourceAttribute("BrowserToRunWith")] string browser,
            [ValueSourceAttribute("UpdateUserProfileTestCaseFalse")] InputProfile inputProfile)
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
            webDriver.FindElement(By.Id("userFullName")).SendKeys(inputProfile.fullname);

            webDriver.FindElement(By.Id("userEmail")).Clear();
            webDriver.FindElement(By.Id("userEmail")).SendKeys(inputProfile.email);

            {
                var dropdown = webDriver.FindElement(By.Id("userGender"));
                dropdown.FindElement(By.XPath($"//option[. = '{inputProfile.gender}']")).Click();
            }

            webDriver.FindElement(By.CssSelector(".ProfileEdit-Button")).Click();

            //Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }
    }
}
