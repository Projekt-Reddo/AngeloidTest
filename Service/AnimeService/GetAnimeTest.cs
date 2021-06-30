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
    [TestFixture]
    public class GetAnimeTest : AnimeServiceTest
    {
        //Test Case for Update user info
        public static IEnumerable<TestCaseData> GetAnimeTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    17, "Hyouka"
                );
                yield return new TestCaseData(
                    29, "Charlotte"
                );
            }
        }

        //Test Update User Info method --- TRUE
        [Test, Timeout(2000)]
        [TestCaseSource("GetAnimeTestCaseTrue")]
        public async Task GetAnimeTestTrue(int animeId, string animeName)
        {
            //Arrange in TestCaseSource

            //Act
            var anime = await _animeService.GetAnime(animeId);

            //Assert
            Assert.That(anime.AnimeName, Is.EqualTo(animeName));
        }

        //Test Case for Get Anime
        public static IEnumerable<TestCaseData> GetAnimeTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    0
                );
                yield return new TestCaseData(
                    6969
                );
            }
        }

        //Test Get Anime method --- FALSE
        [Test, Timeout(2000)]
        [TestCaseSource("GetAnimeTestCaseFalse")]
        public async Task GetAnimeTestFalse(int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var anime = await _animeService.GetAnime(animeId);

            //Assert
            Assert.That(anime, Is.Null);
        }
    }
}