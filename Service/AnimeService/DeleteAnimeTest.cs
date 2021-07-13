
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class DeleteAnimeTest : AnimeServiceTest
    {
        //Test Case True for Delete Anime
        public static IEnumerable<TestCaseData> DeleteAnimeTestCaseTrue
        {
            get
            {
                // Delete an anime in database
                yield return new TestCaseData(
                    17
                );
            }
        }

        //Test Delete Anime method --- TRUE
        [Test]
        [TestCaseSource("DeleteAnimeTestCaseTrue")]
        public async Task DeleteAnimeTestTrue(int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.DeleteAnime(animeId);

            //Assert
            Assert.That(rs, Is.GreaterThan(0));
        }

        //Test Case True for Delete Anime
        public static IEnumerable<TestCaseData> DeleteAnimeTestCaseFalse
        {
            get
            {
                // Delete an anime by null id
                yield return new TestCaseData(
                    null
                );
                // Delete an anime doesn't exist in data base
                yield return new TestCaseData(
                    199
                );
            }
        }

        //Test Delete Anime method --- FALSE
        [Test]
        [TestCaseSource("DeleteAnimeTestCaseFalse")]
        public async Task DeleteAnimeTestFalse(int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _animeService.DeleteAnime(animeId);

            //Assert
            Assert.That(rs, Is.EqualTo(0));
        }
    }
}