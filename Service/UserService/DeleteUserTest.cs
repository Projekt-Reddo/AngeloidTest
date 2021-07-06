using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Angeloid.Models;
using Angeloid.DataContext;
using Angeloid.Services;

namespace AngeloidTest.Service.UserService
{
    public class DeleteUserTest : UserServiceTest
    {
        //Test Case True for Delete User
        public static IEnumerable<TestCaseData> DeleteUserTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    2
                );
            }
        }

        //Test Delete User method --- TRUE
        [Test]
        [TestCaseSource("DeleteUserTestCaseTrue")]
        public async Task DeleteUserTestTrue(int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.DeleteUserById(userId);

            //Assert
            Assert.That(rs, Is.EqualTo(1));
        }

        //Test Case True for Delete Anime
        public static IEnumerable<TestCaseData> DeleteUserTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    null
                );

                yield return new TestCaseData(
                    199
                );
            }
        }

        //Test Delete Anime method --- FALSE
        [Test]
        [TestCaseSource("DeleteUserTestCaseFalse")]
        public async Task DeleteUserTestFalse(int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.DeleteUserById(userId);

            //Assert
            Assert.That(rs, Is.EqualTo(0));
        }
    }
}