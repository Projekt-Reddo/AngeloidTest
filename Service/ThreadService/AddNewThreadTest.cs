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

    }
}