using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class SearchTest : SearchServiceTest
    {
        public static IEnumerable<TestCaseData> SearchAnimeTestCaseTrue
        {
            get
            {
                // Search an anime by key text
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "Hyouka",
                        Year = "",
                        SeasonName = "",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                                TagId = 1
                            }
                        }
                    }
                );
                // Search anime by tag
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "",
                        Year = "",
                        SeasonName = "",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                                TagId = 1
                            }
                        }
                    }
                );
                // Search anime by season
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "",
                        Year = "1992",
                        SeasonName = "Spring",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                                TagId = 1
                            }
                        }
                    }
                );
                // Search an anime by all true attribute
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "Charlotte",
                        Year = "2015",
                        SeasonName = "Fall",
                        Episode = "2",
                        Tags = new[]
                        {
                            new Tag{
                                TagId = 2
                            },
                            new Tag{
                                TagId = 3
                            }
                        }
                    }
                );
            }
        }

        //Test Search Anime method --- TRUE
        [Test]
        [TestCaseSource("SearchAnimeTestCaseTrue")]
        public async Task SearchTrue(Search search)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _searchService.Search(search);

            //Assert
            Assert.That(rs.Count, Is.GreaterThan(0));
        }

        public static IEnumerable<TestCaseData> SearchAnimeTestFalse
        {
            get
            {
                yield return new TestCaseData(
                    // Search with Whitespaces
                    new Search
                    {
                        AnimeName = "                         ",
                        Year = "",
                        SeasonName = "",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                            }
                        }
                    }
                );
                // Search anime doesn'exist in database
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "----------------",
                        Year = "",
                        SeasonName = "",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                            }
                        }
                    }
                );
                // Search an anime with wrong tags
                yield return new TestCaseData(
                    new Search
                    {
                        AnimeName = "Hyouka",
                        Year = "",
                        SeasonName = "",
                        Episode = "0",
                        Tags = new[]
                        {
                            new Tag{
                                TagId = 2
                            }
                        }
                    }
                );
            }
        }

        //Test Search Anime method --- False
        [Test]
        [TestCaseSource("SearchAnimeTestFalse")]
        public async Task SearchFalse(Search search)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _searchService.Search(search);

            //Assert
            Assert.That(rs.Count, Is.EqualTo(0));
        }
    }
}