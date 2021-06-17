using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AngeloidTest.Service.ThreadService
{
    [TestFixture]
    public class GetThreadByIdTest:ThreadServiceTest
    {
        //Test Case for GetThreadById 
        public static IEnumerable<TestCaseData> GetThreadByIdTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    1
                );
                yield return new TestCaseData(
                    2
                );
            }
        }
        public static IEnumerable<TestCaseData> GetThreadByIdTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    3
                );
            }
        }

        [Test]
        [TestCaseSource("GetThreadByIdTestCaseTrue")]
        public async Task GetThreadByIdTrue(int threadId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.GetThreadById(threadId);

            //Assert
            Assert.NotNull(rs);
        }

        [Test]
        [TestCaseSource("GetThreadByIdTestCaseFalse")]
        public async Task GetThreadByIdFalse(int threadId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.GetThreadById(threadId);

            //Assert
            Assert.IsNull(rs);
        }

    }
}