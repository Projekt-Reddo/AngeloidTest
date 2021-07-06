using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Angeloid.Models;
using Angeloid.DataContext;
using Angeloid.Services;
using System.Text;
using System.Threading.Tasks;

namespace AngeloidTest
{
    [TestFixture]
    public class UpdateUserAvatarTest : UserServiceTest
    {
        //Test Case for Update user avatar
        public static IEnumerable<TestCaseData> UpdateUserAvatarTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 1,
                        Avatar = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                    }, 1
                );
            }
        }

        //Test method Update User Avatar --- TRUE
        [Test]
        [TestCaseSource("UpdateUserAvatarTestCaseTrue")]
        public async Task UpdateUserAvatarTestTrue(User updateUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserAvatar(updateUser, userId);

            //Assert
            Assert.AreEqual(1, rs);
        }

        //Test Case for Update user avatar
        public static IEnumerable<TestCaseData> UpdateUserAvatarTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 0,
                        Avatar = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                    }, 0
                );
            }
        }

        //Test Test method Update User Avatar --- FALSE
        [Test]
        [TestCaseSource("UpdateUserAvatarTestCaseFalse")]
        public async Task UpdateUserAvatarTestFalse(User updateUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserAvatar(updateUser, userId);

            //Assert
            Assert.AreEqual(0, rs);
        }
    }
}