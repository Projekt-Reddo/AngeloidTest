using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class ViewAnimeDetailsTest : AnimeServiceTest
    {
        //Test Case True for Update Anime
        public static IEnumerable<TestCaseData> ViewAnimeDetailsTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    17
                );
                yield return new TestCaseData(
                    29
                );
            }
        }

        //Test Update Anime method --- TRUE
        [Test]
        [TestCaseSource("ViewAnimeDetailsTestCaseTrue")]
        public async Task UpdateAnimeTestTrue( int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.GetAnime( animeId);

            //Assert
            Assert.NotNull(rs);
        }

        //Test Case False for Update Anime
        public static IEnumerable<TestCaseData> ViewAnimeDetailsTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    2
                );
                yield return new TestCaseData(
                    3
                );                
            }
        }

        //Test Update Anime method --- FALSE
        [Test]
        [TestCaseSource("ViewAnimeDetailsTestCaseFalse")]
        public async Task UpdateAnimeTestFalse( int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.GetAnime( animeId);

            //Assert
            Assert.IsNull(rs);
        }
    }
}