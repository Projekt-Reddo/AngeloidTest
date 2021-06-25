using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Angeloid.Models;
using Angeloid.DataContext;
using Angeloid.Services;
using System.Text;
using System.Threading.Tasks;

namespace AngeloidTest
{
    // [TestFixture]
    public class CreateAnimeTest : AnimeServiceTest
    {
        //Test Case for Create Anime
        public static IEnumerable<TestCaseData> CreateAnimeTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeName = "New Anime",
                        Content = "Lorem ipsum dolor sit amet, consectetur's adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 'watashi wa tobitai' - PCorn, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Thumbnail = getRandomBytes(),
                        Status = "Airing",
                        Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                        View = 1119830,
                        EpisodeDuration = "24 min per ep",
                        Episode = "13",
                        StartDay = "Oct 4, 2018",
                        Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                        SeasonId = 4,
                        StudioId = 132,
                        Tags = {
                            new Tag {
                                TagId = 1,
                                TagName = "Slice Of Life",
                                TagDescription = ""
                            },
                            new Tag {
                                TagId = 2,
                                TagName = "Drama",
                                TagDescription = ""
                            }
                        }
                    }, 1
                );
                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeName = "New New Anime",
                        Thumbnail = getRandomBytes(),
                        Status = "Not Air",
                        View = 0,
                        SeasonId = 4,
                        StudioId = 132,
                    }, 1
                );
                yield return new TestCaseData(
                    new Anime
                    {
                        AnimeName = "New New New Anime",
                        Status = "Not Air",
                        View = 0,
                        SeasonId = 4,
                        StudioId = 132,
                    }, 1
                );
            }
        }

        //Test Create Anime method --- TRUE
        [Test]
        [TestCaseSource("CreateAnimeTestCaseTrue")]
        public async Task CreateAnimeTrue(Anime anime, int animeInserted)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.InsertAnime(anime);

            //Assert
            Assert.That(rs, Is.EqualTo(animeInserted));
        }
    }
}