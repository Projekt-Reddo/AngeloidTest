using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class UpdateAnimeTest : AnimeServiceTest
    {
        //Test Case True for Update Anime
        public static IEnumerable<TestCaseData> UpdateAnimeTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeId = 17,
                        AnimeName = "Hyouka Season 2",
                        Content = "Eru chan ga kawai",
                        Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Status = "",
                        Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Trailer = "https://www.youtube.com/embed/N5nNKAVB4O4?enablejsapi=1&wmode=opaque&autoplay=1",
                        View = 10378,
                        EpisodeDuration = "30 min per ep",
                        Episode = "24",
                        StartDay = "Apr 23, 2015",
                        Web = "https://myanimelist.net/anime/12189/Hyouka",
                        Season = new Season
                        {
                            SeasonId = 4,
                            Year = "2006",
                            SeasonName = "Winter"
                        },
                        StudioId = 15,
                        Characters = new[] {
                            new Character {
                                CharacterName = "Chitanda Eru",
                                CharacterRole = "Main",
                                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Sakura Ayane",
                                    SeiyuuImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                },
                            },
                        },
                        Tags = new[] {
                            new Tag {
                                TagId = 2,
                                TagName = "Drama",
                                TagDescription = ""
                            }
                        }
                    }, 17
                );

                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeId = 29,
                        AnimeName = "Charlotte Season 2",
                        Content = "Le le le le le",
                        Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Status = "",
                        Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Trailer = "https://www.youtube.com/embed/6AgEzww-a0w?enablejsapi=1&wmode=opaque&autoplay=1",
                        View = 1174381,
                        EpisodeDuration = "24 min per ep",
                        Episode = "12",
                        StartDay = "Jan 10, 2022",
                        Web = "https://myanimelist.net/anime/28999/Charlotte",
                        Season = new Season
                        {
                            SeasonId = 3,
                            Year = "2015",
                            SeasonName = "Fall"
                        },
                        StudioId = 2,
                        Characters = new[] {
                            new Character {
                                CharacterName = "Tomori Nao",
                                CharacterRole = "Main",
                                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Sakura Ayane",
                                    SeiyuuImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                },
                            },
                            new Character {
                                CharacterName = "Otosaka Yuu",
                                CharacterRole = "Main",
                                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Uchiyama Kouki",
                                    SeiyuuImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                },
                            },
                        },
                        Tags = new[] {
                            new Tag {
                                TagId = 2,
                                TagName = "Drama",
                                TagDescription = ""
                            },
                            new Tag {
                                TagId = 3,
                                TagName = "Romance",
                                TagDescription = ""
                            },
                        }
                    }, 29
                );

                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeId = 39,
                        AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                        Content = "La la la la la",
                        Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Status = "Finished Airing",
                        Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                        View = 1119830,
                        EpisodeDuration = "24 min per ep",
                        Episode = "13",
                        StartDay = "Oct 4, 2018",
                        Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                        SeasonId = 4,
                        StudioId = 132,
                        Season = new Season
                        {
                            SeasonId = 3,
                            Year = "2015",
                            SeasonName = "Fall"
                        },
                        Characters = new[] {
                            new Character {
                                CharacterName = "Sakurajima Mai",
                                CharacterRole = "Main",
                                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Sakura Ayane",
                                    SeiyuuImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                },
                            },
                            new Character {
                                CharacterName = "Futaba Rio",
                                CharacterRole = "Supporting",
                                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                Seiyuu = new Seiyuu {
                                    SeiyuuName = "Tanezaki Atsumi",
                                    SeiyuuImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                                },
                            },
                        },
                        Tags = new[] {
                            new Tag {
                                TagId = 1,
                                TagName = "Slice Of Life",
                                TagDescription = ""
                            },
                            new Tag {
                                TagId = 2,
                                TagName = "Drama",
                                TagDescription = ""
                            },
                            new Tag {
                                TagId = 3,
                                TagName = "Romance",
                                TagDescription = ""
                            },
                        }
                    }, 39
                );
            }
        }

        //Test Update Anime method --- TRUE
        [Test]
        [TestCaseSource("UpdateAnimeTestCaseTrue")]
        public async Task UpdateAnimeTestTrue(Anime anime, int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.UpdateAnime(anime, animeId);

            //Assert
            Assert.That(rs, Is.GreaterThan(0));
        }

        //Test Case False for Update Anime
        public static IEnumerable<TestCaseData> UpdateAnimeTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                        Content = "La la la la la",
                        Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Status = "Finished Airing",
                        Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                        Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                        View = 1119830,
                        EpisodeDuration = "24 min per ep",
                        Episode = "13",
                        StartDay = "Oct 4, 2018",
                        Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                        SeasonId = 4,
                        StudioId = 132,
                    }, 100
                );
                
                yield return new TestCaseData(
                    new Anime
                    {

                    }, 17
                );
            }
        }

        //Test Update Anime method --- FALSE
        [Test]
        [TestCaseSource("UpdateAnimeTestCaseFalse")]
        public async Task UpdateAnimeTestFalse(Anime anime, int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.UpdateAnime(anime, animeId);

            //Assert
            Assert.That(rs, Is.GreaterThan(0));
        }
    }
}