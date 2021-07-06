using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Angeloid.Models;
using Angeloid.DataContext;
using Angeloid.Services;
using System.Text;
using System.Threading.Tasks;

namespace AngeloidTest.Service.UserService
{
    [TestFixture]
    public class ListAllUserTest : UserServiceTest
    {
        [Test, Timeout(2000)]
        public async Task ListAllUserTestTrue() {
            //Arrange in TestCaseSource

            //Act
            var userList = await _userService.ListAllUser();

            //Assert: 2 is number of NonAdmin user
            Assert.That(userList.Count, Is.EqualTo(2));
        }
    }
}