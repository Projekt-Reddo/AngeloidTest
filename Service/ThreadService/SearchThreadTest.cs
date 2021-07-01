using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest.Service.ThreadService
{
    public class SearchThreadTest: ThreadServiceTest
    {
        // test cases for SearchThread
        public static IEnumerable<TestCaseData> SearchThreadTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new SearchThread{
                        searchString = "Aji"
                    }, 2
                );
                yield return new TestCaseData(
                    new SearchThread{
                        searchString = "Thread"
                    }, 4
                );
            }
        }
        public static IEnumerable<TestCaseData> SearchThreadTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new SearchThread{
                        searchString = "Baka"
                    }, 0
                );
                yield return new TestCaseData(
                    new SearchThread{
                        searchString = "TaiHen"
                    }, 0
                );
            }
        }

        [Test]
        [TestCaseSource("SearchThreadTestCaseTrue")] 
         public async Task SearchThreadTrue(SearchThread searchString, int expectedLength)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.SearchThread(searchString);


            //Assert
            Assert.AreEqual(expectedLength, rs.Count());
        }
        [Test]
        [TestCaseSource("SearchThreadTestCaseFalse")] 
         public async Task SearchThreadFalse(SearchThread searchString, int expectedLength)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.SearchThread(searchString);


            //Assert
            Assert.AreEqual(expectedLength, rs.Count());
        }
    }
}