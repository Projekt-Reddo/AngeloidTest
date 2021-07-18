using OpenQA.Selenium;
using NUnit.Framework;
using Angeloid.Models;
using OpenQA.Selenium.Interactions;

namespace AngeloidTest.IntegrationSystem
{
    [TestFixture]
    public class UpdateAnimeTest : WebDriverSetUp
    {
        public static Anime[] AnimeFormTrue = new Anime[] {
                // Update anime name
                new Anime
                    {
                        AnimeName = "Kanojo mo kanojo",
                    },
                // Update season and year
                new Anime
                    {
                        Season = new Season
                        {
                            Year = "2000",
                            SeasonName = "Summer"
                        },
                    },
                // Update Studio
                new Anime
                    {
                        Studio = new Studio
                        {
                            StudioName = "Picona",
                        }
                    },
                // Update Characters
                new Anime
                {
                    Characters = new[] {
                        new Character{
                            CharacterName = "Kuriyama Mirai",
                            CharacterRole = "Main",
                            Seiyuu = new Seiyuu{
                                SeiyuuName = "Taneda Risa"
                            }
                        }
                    }
                },

                // Update Tags
                new Anime
                {
                    Tags = new[] {
                        new Tag{
                            TagName = "Comedy",
                        },
                        new Tag{
                            TagName = "Romance",
                        },
                        new Tag{
                            TagName = "Demons",
                        },
                    }
                },

                // Update all attribute
                new Anime
                    {
                        AnimeName = "Kanojo mo kanojo",
                        Season = new Season
                        {
                            Year = "2021",
                            SeasonName = "Fall"
                        },
                        Studio = new Studio
                        {
                            StudioName = "MAPPA",
                        },
                        Characters = new[] {
                            new Character {
                                CharacterName = "Kiryuu Shino",
                                CharacterRole = "Supporting",
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Takahashi Rie",
                                },
                            },
                            new Character {
                                CharacterName = "Hoshizaki Rika",
                                CharacterRole = "Main",
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Taketatsu Ayana",
                                },
                            },
                        },
                        Tags = new[] {
                            new Tag {
                                TagName = "Yuri",
                            },
                            new Tag {
                                TagName = "Harem",
                            },
                        }
                    },
        };

        [Test]
        public void UpdateAnimeTrue([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("AnimeFormTrue")] Anime anime)
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

            //Select an anime which need to Update
            webDriver.FindElement(By.CssSelector("tr:nth-child(2) .btn-warning")).Click();

            // Image URL
            var image = @"D:\MyImg\PxArknight\Arknights.jpg";

            //Update Anime Thubnail
            webDriver.FindElement(By.Id("thumbnail")).SendKeys(image);

            // //Update Anime Wallpaper
            webDriver.FindElement(By.Id("wallpaper")).SendKeys(image);

            // //Update Anime Name
            if (anime.AnimeName != "")
            {
                webDriver.FindElement(By.Id("animeName")).Clear();
                webDriver.FindElement(By.Id("animeName")).SendKeys(anime.AnimeName);
            }

            //Update Anime Studio
            if (anime.Studio.StudioName != "")
            {
                webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".col-12:nth-child(2) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + anime.Studio.StudioName + "']")).Click();
                }
            }

            //Update Anime Description
            if (anime.Content != "")
            {
                webDriver.FindElement(By.Id("description")).Clear();
                webDriver.FindElement(By.Id("description")).SendKeys(anime.Content);
            }

            //Update Anime Episodes
            if (anime.Episode != "")
            {
                webDriver.FindElement(By.Id("episodes")).Clear();
                webDriver.FindElement(By.Id("episodes")).SendKeys(anime.Episode);
            }

            //Update Anime Episodes Duration
            if (anime.EpisodeDuration != null)
            {
                webDriver.FindElement(By.Id("duration")).Clear();
                webDriver.FindElement(By.Id("duration")).SendKeys(anime.EpisodeDuration);
            }

            //Update Anime Season
            if (anime.Season.SeasonName != "")
            {
                webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + anime.Season.SeasonName + "']")).Click();
                }
            }

            //Update Anime Year
            if (anime.Season.Year != "")
            {
                webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select")).Click();
                {
                    var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select"));
                    dropdown.FindElement(By.XPath("//option[. = '" + anime.Season.Year + "']")).Click();
                }
            }

            //Update Anime Status
            if (anime.Status != "")
            {
                webDriver.FindElement(By.Id("status")).Clear();
                webDriver.FindElement(By.Id("status")).SendKeys(anime.Status);
            }

            //Update Anime Start Day
            if (anime.StartDay != "")
            {
                webDriver.FindElement(By.Id("startDay")).Clear();
                webDriver.FindElement(By.Id("startDay")).SendKeys(anime.StartDay);
            }

            //Update Anime Web Link
            if (anime.Web != "")
            {
                webDriver.FindElement(By.Id("web")).Clear();
                webDriver.FindElement(By.Id("web")).SendKeys(anime.Web);
            }

            //Update Anime Trailer Link
            if (anime.Trailer != "")
            {
                webDriver.FindElement(By.Id("trailer")).Clear();
                webDriver.FindElement(By.Id("trailer")).SendKeys(anime.Trailer);
            }

            // Update Anime Tags
            if (anime.Tags != null)
            {
                var count = 1;
                foreach (Tag Tag in anime.Tags)
                {
                    webDriver.FindElement(By.CssSelector(".search-box:nth-child(1) > .form-select")).Click();
                    {
                        var dropdown = webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") > .form-select"));
                        dropdown.FindElement(By.XPath("//option[. = '" + Tag.TagName + "']")).Click();
                    }
                    count += 1;
                }
            }

            // Update Anime Characters
            if (anime.Characters != null)
            {
                var count = 1;
                foreach (Character character in anime.Characters)
                {
                    webDriver.FindElement(By.CssSelector(".AddCharacterButton")).Click();
                    //Update Character Image
                    if (image != null)
                    {
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterImage")).Click();
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterImage")).SendKeys(image);
                    }
                    //Update Character Name
                    if (character.CharacterName != "")
                    {
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterName")).Click();
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterName")).SendKeys(character.CharacterName);
                    }
                    //Update Character Role
                    if (character.CharacterRole != "")
                    {
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterRole")).Click();
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #characterRole")).SendKeys(character.CharacterRole);
                    }
                    //Update Seiyuu Name
                    if (character.Seiyuu.SeiyuuName != "")
                    {
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #seiyuuName")).Click();
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #seiyuuName")).SendKeys(character.Seiyuu.SeiyuuName);
                    }
                    //Update Seiyuu Image
                    if (image != null)
                    {
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #seiyuuImage")).Click();
                        webDriver.FindElement(By.CssSelector(".col-12:nth-child(" + count + ") #seiyuuImage")).SendKeys(image);
                    }
                    count += 1;
                }
            }

            //Click "Upload" Button
            webDriver.FindElement(By.CssSelector(".UploadButton")).Click();

            // Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            // Close windows
            webDriver.Close();
        }

        public static Anime[] AnimeFormFalse = new Anime[] {
            // Not Wallpaper season and Thumbnail
                new Anime
                    {
                        Thumbnail = null,
                        Wallpaper = null,
                    },
                // Not input season and year
                new Anime
                    {
                        Season = new Season
                        {
                            Year = "",
                            SeasonName = ""
                        },
                        Studio = new Studio
                        {
                            StudioName = "",
                        },
                    },
        };

        public void UpdateAnimeFalse([ValueSourceAttribute("BrowserToRunWith")] string browser, [ValueSourceAttribute("AnimeFormFalse")] Anime anime)
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

            //Select an anime which need to Update
            webDriver.FindElement(By.CssSelector("tr:nth-child(2) .btn-warning")).Click();

            // Image URL
            var image = "";

            //Update Anime Thubnail
            webDriver.FindElement(By.Id("thumbnail")).SendKeys(image);

            //Update Anime Wallpaper
            webDriver.FindElement(By.Id("wallpaper")).SendKeys(image);

            webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select")).Click();
            {
                var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(3) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = '" + anime.Season.SeasonName + "']")).Click();
            }

            //Update Anime Year
            webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select")).Click();
            {
                var dropdown = webDriver.FindElement(By.CssSelector(".my-1:nth-child(4) > .form-select"));
                dropdown.FindElement(By.XPath("//option[. = '" + anime.Season.Year + "']")).Click();
            }

            //Click "Upload" Button
            webDriver.FindElement(By.CssSelector(".UploadButton")).Click();

            // Log out
            webDriver.FindElement(By.LinkText("Logout")).Click();

            // Close windows
            webDriver.Close();
        }
    }
}
