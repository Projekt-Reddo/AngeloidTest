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
    public class UpdatePasswordTest : UserServiceTest
    {
        //Test Case for User Registration
        public static IEnumerable<TestCaseData> UpdatePasswordTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new UserPassword
                    {
                        OldPassword = "12345678",
                        NewPassword = "87654321"
                    }
                    , 1 
                );
                yield return new TestCaseData(
                    new UserPassword
                    {
                        OldPassword = "admin",
                        NewPassword = "baolocpham"
                    }
                    , 2
                );  
                yield return new TestCaseData(
                    new UserPassword
                    {
                        OldPassword = "admin",
                        NewPassword = "thisisnewpass"
                    }
                    , 3
                );                                 
            }
        }
        // test case where user all ready in database
        public static IEnumerable<TestCaseData> UpdatePasswordTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new UserPassword
                    {
                        OldPassword = "admin",
                        NewPassword = "baolocpham"
                    }
                    , 1
                );
                yield return new TestCaseData(
                    new UserPassword
                    {
                        OldPassword = "baolocpham",
                        NewPassword = "baolocpham"
                    }
                    , 2
                );                                               
            }
        }

        [Test]
        [TestCaseSource("UpdatePasswordTestCaseTrue")]
        public async Task UpdatePasswordTestTrue(UserPassword updatepassUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserPassword(updatepassUser, userId);

            //Assert
            Assert.AreEqual(1,rs);
        }

        [Test]
        [TestCaseSource("UpdatePasswordTestCaseFalse")]
        public async Task UpdatePasswordTestFalse(UserPassword updatepassUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.UpdateUserPassword(updatepassUser, userId);

            //Assert
            Assert.AreEqual(0,rs);
        }
    }
}