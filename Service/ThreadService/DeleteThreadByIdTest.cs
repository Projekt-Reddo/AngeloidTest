using System.Collections.Generic;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest.Service.ThreadService
{
    public class DeleteThreadByIdTest : ThreadServiceTest
    {
        // Test Case for DeleteThreadById
        public static IEnumerable<TestCaseData> DeleteThreadByIdTestCaseTrue
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
        public static IEnumerable<TestCaseData> DeleteThreadByIdTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    3
                );

            }
        }
        // [Test]
        // [TestCaseSource("DeleteThreadByIdTestCaseTrue")]
        // public async Task DeleteThreadByIdTrue(int threadId)
        // {
        //     //Arrange in TestCaseSource

        //     //Act
        //     var rs = await _threadService.DeleteThreadById(threadId);

        //     //Assert
        //     Assert.AreEqual(1,rs);
        // }
    }
}