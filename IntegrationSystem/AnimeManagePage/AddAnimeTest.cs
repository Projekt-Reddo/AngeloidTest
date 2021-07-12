using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using Angeloid.Models;
using OpenQA.Selenium.Interactions;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class AddAnimeTest : WebDriverSetUp
    {
        [Test]
        public void AddAnimeFailImage([ValueSourceAttribute("BrowserToRunWith")] string browser)
        {
            //Create web driver object
            Setup(browser);

            // Test name: AddAnimeFalse
            // Step # | name | target | value
            // 1 | open | / | 
            webDriver.Navigate().GoToUrl("https://localhost:3000/");
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
            // 9 | click | css=.shadow-sm > div | 
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();
            // 10 | click | css=.nav-link:nth-child(4) > .p-2:nth-child(2) | 
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            // 11 | click | css=.nav-link:nth-child(2) > .p-2:nth-child(2) | 
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();
            // 12 | click | linkText=Add new | 
            webDriver.FindElement(By.LinkText("Add new")).Click();
            // 17 | type | id=thumbnail |
            webDriver.FindElement(By.Id("thumbnail")).SendKeys("C:\\Users\\bapng\\Pictures\\Yuki\\852313.jpg");
            // webDriver.Close();
        }

        //Test Case for Anime Fail
        public static List<Anime> AnimeFail = new List<Anime> {
            new Anime { AnimeName = "" },
            new Anime { AnimeName = "Koe no Katachi" },
            new Anime { AnimeName = "test" + Guid.NewGuid().ToString() },
        };

        [Test]
        public void AddAnimeFail([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("AnimeFail")] Anime inputAnime)
        {
            //Create web driver object
            Setup(browser);

            // Test name: AddAnimeFalse
            // Step # | name | target | value
            // 1 | open | / | 
            webDriver.Navigate().GoToUrl("https://localhost:3000/");
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
            // 9 | click | css=.shadow-sm > div | 
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();
            // 10 | click | css=.nav-link:nth-child(4) > .p-2:nth-child(2) | 
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(4) > .p-2:nth-child(2)")).Click();
            // 11 | click | css=.nav-link:nth-child(2) > .p-2:nth-child(2) | 
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();
            // 12 | click | linkText=Add new | 
            webDriver.FindElement(By.LinkText("Add new")).Click();
            // 18 | click | id=animeName | 
            webDriver.FindElement(By.Id("animeName")).Click();
            // 19 | type | id=animeName | Anime Name
            webDriver.FindElement(By.Id("animeName")).SendKeys(inputAnime.AnimeName);

            if (inputAnime != null) {
                // 20 | click | css=.col-12:nth-child(2) > .form-select | 
                webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select")).Click();
                // 21 | select | css=.col-12:nth-child(2) > .form-select | label=Studio Pierrot
                {
                var dropdown = webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Studio Pierrot']")).Click();
                }
                // 22 | click | id=episodes | 
                webDriver.FindElement(By.Id("episodes")).Click();
                // 23 | type | id=episodes | 12
                webDriver.FindElement(By.Id("episodes")).SendKeys("12");
                // 24 | click | id=duration | 
                webDriver.FindElement(By.Id("duration")).Click();
                // 25 | type | id=duration | 24 min per ep
                webDriver.FindElement(By.Id("duration")).SendKeys("24 min per ep");
                // 26 | click | id=description | 
                webDriver.FindElement(By.Id("description")).Click();
                // 27 | type | id=description | None
                webDriver.FindElement(By.Id("description")).SendKeys("None");
                // 28 | click | css=.my-1:nth-child(3) > .form-select | 
                webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select")).Click();
                // 29 | select | css=.my-1:nth-child(3) > .form-select | label=Summer
                {
                var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Summer']")).Click();
                }
                // 30 | click | css=.my-1:nth-child(4) > .form-select | 
                webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select")).Click();
                // 31 | select | css=.my-1:nth-child(4) > .form-select | label=2021
                {
                var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = '2021']")).Click();
                }
            }

            if (inputAnime.AnimeName.StartsWith("test")) {
                // 20 | click | css=.col-12:nth-child(2) > .form-select | 
                webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select")).Click();
                // 21 | select | css=.col-12:nth-child(2) > .form-select | label=Studio Pierrot
                {
                var dropdown = webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Studio Pierrot']")).Click();
                }
                // 22 | click | id=episodes | 
                webDriver.FindElement(By.Id("episodes")).Click();
                // 23 | type | id=episodes | 12
                webDriver.FindElement(By.Id("episodes")).SendKeys("12");
                // 24 | click | id=duration | 
                webDriver.FindElement(By.Id("duration")).Click();
                // 25 | type | id=duration | 24 min per ep
                webDriver.FindElement(By.Id("duration")).SendKeys("24 min per ep");
                // 26 | click | id=description | 
                webDriver.FindElement(By.Id("description")).Click();
                // 27 | type | id=description | None
                webDriver.FindElement(By.Id("description")).SendKeys("None");
                // 28 | click | css=.my-1:nth-child(3) > .form-select | 
                webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select")).Click();
                // 29 | select | css=.my-1:nth-child(3) > .form-select | label=Summer
                {
                var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = 'Summer']")).Click();
                }
            }

            // 13 | click | css=.UploadButton | 
            webDriver.FindElement(By.CssSelector(".UploadButton")).Click();
            // 14 | click | css=.btn-warning | 
            webDriver.FindElement(By.CssSelector(".btn-warning")).Click();
            // 15 | click | linkText=Logout | 
            webDriver.FindElement(By.LinkText("Logout")).Click();
            webDriver.Close();
        }

        //Test Case for login
        public static List<Anime> AnimeTrue = new List<Anime> {
            new Anime { 
                AnimeName = Guid.NewGuid().ToString(),
            },
            new Anime {
                AnimeName = Guid.NewGuid().ToString(),
                Characters = new [] {
                    new Character {
                        CharacterName = "Name",
                        CharacterRole = "Supporting",
                        Seiyuu = new Seiyuu {
                            SeiyuuName = Guid.NewGuid().ToString()
                        }
                    }
                }
            },
            new Anime {
                AnimeName = Guid.NewGuid().ToString(),
                Characters = new [] {
                    new Character {
                        CharacterName = "Name",
                        CharacterRole = "Supporting",
                        Seiyuu = new Seiyuu {
                            SeiyuuName = "Hanamura Satomi"
                        }
                    }
                }
            },
        };

        [Test]
        public void AddAnimeTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("AnimeTrue")] Anime inputAnime)
        {
            //Create web driver object
            Setup(browser);

            // Test name: AddAnime
            // Step # | name | target | value
            // 1 | open | / | 
            webDriver.Navigate().GoToUrl("https://localhost:3000/");
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
            // 9 | click | css=.shadow-sm > div | 
            webDriver.FindElement(By.CssSelector(".shadow-sm > div")).Click();
            // 10 | click | linkText=Admin | 
            webDriver.FindElement(By.LinkText("Admin")).Click();
            // 11 | click | css=.nav-link:nth-child(2) > .p-2:nth-child(2) | 
            webDriver.FindElement(By.CssSelector(".nav-link:nth-child(2) > .p-2:nth-child(2)")).Click();
            // 12 | click | linkText=Add new | 
            webDriver.FindElement(By.LinkText("Add new")).Click();
            
            IWebElement thumbnail = webDriver.FindElement(By.Id("thumbnail"));
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(thumbnail);

            // 17 | type | id=thumbnail |
            webDriver.FindElement(By.Id("thumbnail")).SendKeys("C:\\Users\\bapng\\Pictures\\Yuki\\E4rTPFXVkAEHYpA.png");
            
            actions.MoveToElement(webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select")));
            
            // 18 | click | id=animeName | 
            webDriver.FindElement(By.Id("animeName")).Click();
            // 19 | type | id=animeName | Anime Name
            webDriver.FindElement(By.Id("animeName")).SendKeys(inputAnime.AnimeName);
            // 20 | click | css=.col-12:nth-child(2) > .form-select | 
            webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select")).Click();
            // 21 | select | css=.col-12:nth-child(2) > .form-select | label=Studio Pierrot
            {
            var dropdown = webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select"));
            dropdown.FindElement(By.XPath("//option[. = 'Studio Pierrot']")).Click();
            }
            // 22 | click | id=episodes | 
            webDriver.FindElement(By.Id("episodes")).Click();
            // 23 | type | id=episodes | 12
            webDriver.FindElement(By.Id("episodes")).SendKeys("12");
            // 24 | click | id=duration | 
            webDriver.FindElement(By.Id("duration")).Click();
            // 25 | type | id=duration | 24 min per ep
            webDriver.FindElement(By.Id("duration")).SendKeys("24 min per ep");
            // 26 | click | id=description | 
            webDriver.FindElement(By.Id("description")).Click();
            // 27 | type | id=description | None
            webDriver.FindElement(By.Id("description")).SendKeys("None");
            // 28 | click | css=.my-1:nth-child(3) > .form-select | 
            webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select")).Click();
            // 29 | select | css=.my-1:nth-child(3) > .form-select | label=Summer
            {
            var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select"));
            dropdown.FindElement(By.XPath("//option[. = 'Summer']")).Click();
            }
            // 30 | click | css=.my-1:nth-child(4) > .form-select | 
            webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select")).Click();
            // 31 | select | css=.my-1:nth-child(4) > .form-select | label=2021
            {
            var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select"));
            dropdown.FindElement(By.XPath("//option[. = '2021']")).Click();
            }

            if (inputAnime.Characters != null) {
                foreach (Character character in inputAnime.Characters) {
                    // 37 | click | css=.AddCharacterButton | 
                    webDriver.FindElement(By.CssSelector(".AddCharacterButton")).Click();
                    // 38 | click | id=characterImage | 
                    webDriver.FindElement(By.Id("characterImage")).Click();
                    // 39 | type | id=characterImage | C:\fakepath\E4rTPFXVkAEHYpA.png
                    webDriver.FindElement(By.Id("characterImage")).SendKeys("C:\\Users\\bapng\\Pictures\\Yuki\\E4rTPFXVkAEHYpA.png");
                    // 40 | click | id=characterName | 
                    webDriver.FindElement(By.Id("characterName")).Click();
                    // 41 | type | id=characterName | nme
                    webDriver.FindElement(By.Id("characterName")).SendKeys(character.CharacterName);
                    // 42 | click | id=seiyuuName | 
                    webDriver.FindElement(By.Id("seiyuuName")).Click();
                    // 43 | type | id=seiyuuName | name
                    webDriver.FindElement(By.Id("seiyuuName")).SendKeys(character.Seiyuu.SeiyuuName);
                    // 44 | click | id=characterRole | 
                    webDriver.FindElement(By.Id("characterRole")).Click();
                    // 45 | type | id=characterRole | main
                    webDriver.FindElement(By.Id("characterRole")).SendKeys(character.CharacterRole);
                }
            }

            actions.MoveToElement(webDriver.FindElement(By.CssSelector(".UploadButton")));

            // 32 | click | css=.UploadButton | 
            webDriver.FindElement(By.CssSelector(".UploadButton")).Click();
            // 15 | click | linkText=Logout | 
            webDriver.FindElement(By.LinkText("Logout")).Click();
            webDriver.Close();
        }
    }
}