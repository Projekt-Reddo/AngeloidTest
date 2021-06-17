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
    public class RegisterTest : UserServiceTest
    {
        //Test Case for User Registration
        public static IEnumerable<TestCaseData> RegisterTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "NewUser",
                        Password = "admin",
                        Email = "phuc69@gmail.com"
                    }
                );
            }
        }
        // test case where user all ready in database
        public static IEnumerable<TestCaseData> RegisterTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "BaoLoc",
                        Password = "admin",
                        Email = "Baoloc@gmail.com",
                    }
                );
            }
        }

        [Test]
        [TestCaseSource("RegisterTestCaseTrue")]
        public async Task RegisterTestTrue(User registerUser)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.Register(registerUser);

            //Assert
            Assert.AreEqual(1,rs);
        }

        [Test]
        [TestCaseSource("RegisterTestCaseFalse")]
        public async Task RegisterTestFalse(User registerUser)
        {
            //Arrange in TestCaseSource

            //Act
            var rs = await _userService.Register(registerUser);

            //Assert
            Assert.AreEqual(0,rs);
        }
    }
}