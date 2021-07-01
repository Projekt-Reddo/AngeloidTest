using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class GetReviewsTest : ReviewServiceTest
    {
        //Test Case for  Get Reviews by AnimeId
        public static IEnumerable<TestCaseData> GetReviewsTestCaseTrue
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

        //Test Get Reviews method --- TRUE
        [Test, Timeout(2000)]
        [TestCaseSource("GetReviewsTestCaseTrue")]
        public async Task GetReviewsTestTrue(int animeId)
        {
            //Arrange in TestCaseSource

            //Act
            var reviews = await _reviewService.GetReviews(animeId);

            //Assert
            Assert.That(reviews.Count, Is.GreaterThan(0));
        }
    }
}