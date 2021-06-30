using System.Collections.Generic;
using System.Threading.Tasks;
using Angeloid.Models;
using NUnit.Framework;

namespace AngeloidTest.Service.ThreadService
{
    [TestFixture]
    public class AddNewThreadTest : ThreadServiceTest
    {
        //Test Case for AddNewThread 
        public static IEnumerable<TestCaseData> AddNewThreadTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new Thread
                    {
                        Title = "Thread 3",
                        Content = "Thread 3 Content",
                        UserId = 1
                    }
                );
                yield return new TestCaseData(
                    new Thread
                    {
                        Title = "Thread 1",
                        Content = "Thread 1 Content",
                        Image = getRandomBytes(),
                        UserId = 2
                    }
                );
            }
        } 
        public static IEnumerable<TestCaseData> AddNewThreadTestCaseFalse
        {
            get
            {
                // yield return new TestCaseData(
                //     new Thread
                //     {
                //         Title = "",
                //         Content = "Thread 3 Content",
                //         Image = null,
                //         UserId = 1
                //     }
                // );
                // yield return new TestCaseData(
                //     new Thread
                //     {
                //         Title = "tí te",
                //         Content = "",
                //         Image = null,
                //         UserId = 1
                //     }
                // );
                yield return new TestCaseData(
                    new Thread
                    {
                        Title = "tí te",
                        Content = "ádasdasdasd",
                        Image = null,
                        // user ID not in db
                        UserId = 3
                    }
                );
            }
        } 

        [Test]
        [TestCaseSource("AddNewThreadTestCaseTrue")]
        public async Task AddNewThreadTrue(Thread thread)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.AddNewThread(thread);

            //Assert
            Assert.Greater(rs,0);
        }
        [Test]
        [TestCaseSource("AddNewThreadTestCaseFalse")]
        public async Task AddNewThreadFalse(Thread thread)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.AddNewThread(thread);

            //Assert
            Assert.AreEqual(0, rs);
        }
    }
}