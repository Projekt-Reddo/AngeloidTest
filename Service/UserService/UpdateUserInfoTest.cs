using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Angeloid.Models;
using Angeloid.DataContext;
using Angeloid.Services;

namespace AngeloidTest
{
    [TestFixture]
    public class UpdateUserInfoTest : UserServiceTest
    {
        //Test Case for Update user info
        public static IEnumerable<TestCaseData> UpdateUserInfoTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 1,
                        Fullname = "Hoang Vi",
                        Email = "hostcode0301@gmail.com",
                        Gender = "Male",
                        Avatar = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                    }, 1
                );
            }
        }

        //Test Update User Info method --- TRUE
        [Test]
        [TestCaseSource("UpdateUserInfoTestCaseTrue")]
        public async Task UpdateUserInfoTestTrue(User updateUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserInfo(updateUser, userId);

            //Assert
            Assert.AreEqual(1, rs);
        }

        //Test Case for Update user info
        public static IEnumerable<TestCaseData> UpdateUserInfoTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 0,
                        Fullname = "Hoang Vi",
                        Email = "hostcode0301@gmail.com",
                        Gender = "Male",
                        Avatar = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                    }, 0
                );
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 1,
                        Fullname = "Tran Thien Phu",
                        Email = "hostcode0301@gmail.com",
                        Gender = "Male",
                        Avatar = null,
                    }, 1
                );
            }
        }

        //Test Update User Info method --- FALSE
        [Test]
        [TestCaseSource("UpdateUserInfoTestCaseFalse")]
        public async Task UpdateUserInfoTestFalse(User updateUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserInfo(updateUser, userId);

            //Assert
            Assert.AreEqual(0, rs);
        }
    }
}