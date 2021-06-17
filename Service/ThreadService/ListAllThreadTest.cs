using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AngeloidTest.Service.ThreadService
{
    [TestFixture]
    public class ListAllThreadTest:ThreadServiceTest
    {
        [Test]
        public async Task ListAllThreadTestMeow()
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _threadService.ListAllThread();
            var dataSize = rs.Count();

            //Assert
            Assert.AreEqual(2,dataSize);
        }
        
    }
}