using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Angeloid.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class GetRateScoreTest : ReviewServiceTest
    {
        //Test Case for Get RateScore by AnimeId user
        public static IEnumerable<TestCaseData> GetRateScoreTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    17,
                    new RatingScoreModel()
                    {
                        one = 0,
                        two = 0,
                        three = 0,
                        four = 0,
                        five = 2
                    }
                );
                yield return new TestCaseData(
                    29,
                    new RatingScoreModel()
                    {
                        one = 0,
                        two = 0,
                        three = 0,
                        four = 1,
                        five = 2
                    }
                );
            }
        }

        //Test Get Reviews method --- TRUE
        [TestCaseSource("GetRateScoreTestCaseTrue")]
        public async Task GetRateScoreTestTrue(int animeId, RatingScoreModel rateScoreExpected)
        {
            //Arrange in TestCaseSource

            //Act
            var rateScore = await _reviewService.GetRateScore(animeId);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(rateScoreExpected), JsonConvert.SerializeObject(rateScore));
        }
    }
}