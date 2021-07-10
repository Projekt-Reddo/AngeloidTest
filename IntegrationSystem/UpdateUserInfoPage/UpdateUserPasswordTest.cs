using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class UpdateUserPasswordTest : WebDriverSetUp
    {
        public class InputPassword
        {
            public string oldPassword { get; set; }
            public string newPassord { get; set; }
            public string reNewpassword { get; set; }
        }

        private static readonly InputPassword[] UpdateUserPasswordTestCaseTrue = new InputPassword[] {
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "phu01",
                reNewpassword = "phu01",
            },
            new InputPassword {
                oldPassword = "phu01",
                newPassord = "12345678901234567890123456789012",
                reNewpassword = "12345678901234567890123456789012",
            },
            new InputPassword {
                oldPassword = "12345678901234567890123456789012",
                newPassord = "12345@&123",
                reNewpassword = "12345@&123",
            },
            new InputPassword {
                oldPassword = "12345@&123",
                newPassord = "12345678",
                reNewpassword = "12345678",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345678",
                reNewpassword = "12345678",
            }
        };

        [Test]
        public void updateUserPasswordTrue(
            [ValueSourceAttribute("BrowserToRunWith")] string browser,
            [ValueSourceAttribute("UpdateUserPasswordTestCaseTrue")] InputPassword inputPassword)
        {
            //Set up browser
            Setup(browser);

            //Go to web url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            webDriver.Manage().Window.Size = new System.Drawing.Size(1298, 729);

            //Login to web
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("hostcode03012");
            webDriver.FindElement(By.Id("password")).SendKeys(inputPassword.oldPassword);
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            //Go to setting page
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Click to change password section
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();

            //Input change password
            webDriver.FindElement(By.Name("InputOldPassword")).Clear();
            webDriver.FindElement(By.Name("InputOldPassword")).SendKeys(inputPassword.oldPassword);
            webDriver.FindElement(By.Name("InputNewPassword")).Clear();
            webDriver.FindElement(By.Name("InputNewPassword")).SendKeys(inputPassword.newPassord);
            webDriver.FindElement(By.Name("InputReNewPassword")).Clear();
            webDriver.FindElement(By.Name("InputReNewPassword")).SendKeys(inputPassword.reNewpassword);
            webDriver.FindElement(By.CssSelector(".col-3:nth-child(13)")).Click();

            //Click button change done
            webDriver.FindElement(By.CssSelector(".btn-warning")).Click();

            //Log out 
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }

        private static readonly InputPassword[] UpdateUserPasswordTestCaseFalse = new InputPassword[] {
            new InputPassword {
                oldPassword = "",
                newPassord = "",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "123456",
                newPassord = "",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "1234",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345",
                reNewpassword = "123456",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "123456789",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "123456789",
                reNewpassword = "1234567890",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "1234567890123456789012345678901212",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345@&123",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345@&123",
                reNewpassword = "1234567",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345<script>@&123",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345678901234567890123456789012",
                reNewpassword = "",
            },
            new InputPassword {
                oldPassword = "12345678",
                newPassord = "12345678901234567890123456789012",
                reNewpassword = "1234567",
            }
        };

        [Test]
        public void updateUserPasswordFalse(
            [ValueSourceAttribute("BrowserToRunWith")] string browser,
            [ValueSourceAttribute("UpdateUserPasswordTestCaseFalse")] InputPassword inputPassword)
        {
            //Set up browser
            Setup(browser);

            //Go to web url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
            webDriver.Manage().Window.Size = new System.Drawing.Size(1298, 729);

            //Login to web
            webDriver.FindElement(By.LinkText("Login")).Click();
            webDriver.FindElement(By.Id("username")).SendKeys("hostcode03012");
            webDriver.FindElement(By.Id("password")).SendKeys("12345678");
            webDriver.FindElement(By.CssSelector(".btn:nth-child(9)")).Click();

            //Go to setting page
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();

            //Click to change password section
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();

            //Input change password
            webDriver.FindElement(By.Name("InputOldPassword")).Clear();
            webDriver.FindElement(By.Name("InputOldPassword")).SendKeys(inputPassword.oldPassword);
            webDriver.FindElement(By.Name("InputNewPassword")).Clear();
            webDriver.FindElement(By.Name("InputNewPassword")).SendKeys(inputPassword.newPassord);
            webDriver.FindElement(By.Name("InputReNewPassword")).Clear();
            webDriver.FindElement(By.Name("InputReNewPassword")).SendKeys(inputPassword.reNewpassword);
            webDriver.FindElement(By.CssSelector(".col-3:nth-child(13)")).Click();

            //Log out 
            webDriver.FindElement(By.LinkText("Logout")).Click();

            //Close browser
            webDriver.Close();
        }
    }
}