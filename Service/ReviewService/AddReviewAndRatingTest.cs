using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class AddReviewAndRatingTest : ReviewServiceTest
    {
        //Test Case for Create Anime
        public static IEnumerable<TestCaseData> AddReviewAndRatingCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new Review
                    {
                        UserId = 1,
                        AnimeId = 39,
                        RateScore = 5,
                        Content = "Good"
                    }
                );
                yield return new TestCaseData(
                    new Review
                    {
                        UserId = 2,
                        AnimeId = 39,
                        Content = "Good Nice"
                    }
                );
                yield return new TestCaseData(
                    new Review
                    {
                        UserId = 3,
                        AnimeId = 39,
                        RateScore = 2,
                    }
                );
            }
        }

        //Test Create Anime method --- TRUE
        [Test]
        [TestCaseSource("AddReviewAndRatingCaseTrue")]
        public async Task AddReviewAndRatingTrue(Review review)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _reviewService.AddReviewAndRating(review);

            //Assert
            Assert.That(rs, Is.GreaterThan(0));
        }
    }
}