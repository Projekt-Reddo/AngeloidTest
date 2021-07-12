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
    public class LoginTest : LogInOutServiceTest
    {
        //Test Case for Login
        public static IEnumerable<TestCaseData> LoginTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "hostcode0301",
                        Password = "12345678"
                    }, 1
                );
            }
        }

        //Test Update User Info method --- TRUE
        [Test]
        [TestCaseSource("LoginTestCaseTrue")]
        public async Task LoginTestTrue(User loginUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var user = await _logInOutService.Login(loginUser);

            //Assert
            Assert.That(user.UserId, Is.EqualTo(userId));
        }

        //Test Case for Update user info
        public static IEnumerable<TestCaseData> LoginTestCaseFalse
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "blabadjsdjhdsdjddf",
                        Password = "12345678"
                    }
                );
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "hostcode0301",
                        Password = "admin"
                    }
                );
                yield return new TestCaseData(
                    new User
                    {
                        UserName = "",
                        Password = ""
                    }
                );
            }
        }

        //Test Update User Info method --- TRUE
        [Test]
        [TestCaseSource("LoginTestCaseFalse")]
        public async Task LoginTestFalse(User loginUser)
        {
            //Arrange in TestCaseSource

            //Act
            var user = await _logInOutService.Login(loginUser);

            //Assert
            Assert.That(user, Is.Null);
        }
    }
}