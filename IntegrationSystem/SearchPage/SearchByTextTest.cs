// Generated by Selenium IDE
using OpenQA.Selenium;
using NUnit.Framework;
using Angeloid.Models;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class SearchByTextTest : WebDriverSetUp
    {
        public static Search[] SearchByTextFormTrue = new Search[] {
            new Search{
                AnimeName = "",
                Year = "",
                SeasonName = "",
                Episode = "",
            },
            new Search{
                AnimeName = "tantei",
                Year = "2021",
                SeasonName = "Summer",
                Episode = "",
            },
            new Search{
                AnimeName = "",
                Year = "",
                SeasonName = "",
                Episode = "Oneshot/Movie",
            },
            new Search{
                AnimeName = "",
                Year = "",
                SeasonName = "",
                Episode = "",
                Tags = new[]{
                    new Tag{
                        TagName = "Action",
                    },
                    new Tag{
                        TagName = "Advanture",
                    },
                    new Tag{
                        TagName = "Drama",
                    },
                }
            },
        };

        [Test]
        public void SearchByTextTestTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("SearchByTextFormTrue")] Search info)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Go to search page
            webDriver.FindElement(By.LinkText("Search")).Click();

            //Enter text key into search form
            if (info.AnimeName != "")
            {
                webDriver.FindElement(By.CssSelector(".form-control")).Click();
                webDriver.FindElement(By.CssSelector(".form-control")).SendKeys(info.AnimeName);
                webDriver.FindElement(By.CssSelector(".form-control")).SendKeys(Keys.Enter);
            }

            //Select the tags of the anime
            if (info.Tags != null)
            {
                foreach (Tag Tag in info.Tags)
                {
                    webDriver.FindElement(By.CssSelector(".search-box:nth-child(1) > .form-select")).Click();
                    {
                        var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(1) > .form-select"));
                        dropdown.FindElement(By.XPath("//option[. = '" + Tag.TagName + "']")).Click();
                    }
                }
            }

            //Select the year of the anime
            if (info.Year != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(2) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(2) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.Year + "']")).Click();
                }
            }

            // //Select the season of the anime
            if (info.SeasonName != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(3) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(3) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.SeasonName + "']")).Click();
                }
            }

            // //Select the format of the anime
            if (info.Episode != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(4) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(4) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.Episode + "']")).Click();
                }
            }

            //Click magnifying glass for searching
            webDriver.FindElement(By.CssSelector(".fa-search")).Click();
        }

        public static Search[] SearchByTextFormFalse = new Search[] {
            new Search{
                AnimeName = "<script>alert('Love you Bao Loc')</script>",
                Year = "",
                SeasonName = "",
                Episode = "",
            },
        };

        [Test]
        public void SearchByTextTestFalse([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("SearchByTextFormFalse")] Search info)
        {
            //Create web driver object
            Setup(browser);

            //Navigate to url
            webDriver.Navigate().GoToUrl("http://localhost:3000/");

            //Go to search page
            webDriver.FindElement(By.LinkText("Search")).Click();

            //Enter text key into search form
            if (info.AnimeName != "")
            {
                webDriver.FindElement(By.CssSelector(".form-control")).Click();
                webDriver.FindElement(By.CssSelector(".form-control")).SendKeys(info.AnimeName);
                webDriver.FindElement(By.CssSelector(".form-control")).SendKeys(Keys.Enter);
            }

            //Select the tags of the anime
            if (info.Tags != null)
            {
                foreach (Tag Tag in info.Tags)
                {
                    webDriver.FindElement(By.CssSelector(".search-box:nth-child(1) > .form-select")).Click();
                    {
                        var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(1) > .form-select"));
                        dropdown.FindElement(By.XPath("//option[. = '" + Tag.TagName + "']")).Click();
                    }
                }
            }

            //Select the year of the anime
            if (info.Year != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(2) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(2) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.Year + "']")).Click();
                }
            }

            // //Select the season of the anime
            if (info.SeasonName != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(3) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(3) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.SeasonName + "']")).Click();
                }
            }

            // //Select the format of the anime
            if (info.Episode != "")
            {
                webDriver.FindElement(By.CssSelector(".search-box:nth-child(4) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".search-box:nth-child(4) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + info.Episode + "']")).Click();
                }
            }

            //Click magnifying glass for searching
            webDriver.FindElement(By.CssSelector(".fa-search")).Click();
        }
    }
}
