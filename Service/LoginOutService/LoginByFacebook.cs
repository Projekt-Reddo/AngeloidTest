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
    public class LoginByFacebookTest : LogInOutServiceTest
    {
        //Test Case for Update user info
        public static IEnumerable<TestCaseData> LoginFacebookTestCaseTrue
        {
            get
            {
                yield return new TestCaseData(
                    new User
                    {
                        FacebookId = "12345",
                        Fullname = "Hốt Tất Liệt",
                        Email = "hostcode0301@gmail.com"
                    }, 1
                );
                yield return new TestCaseData(
                    new User
                    {
                        UserId = 69,
                        FacebookId = "696969",
                        Fullname = "フユキ シロ",
                        Email = "myfacebookemaillll@gmail.com"
                    }, 69
                );
                yield return new TestCaseData(
                    new User
                    {
                        FacebookId = "111111",
                        Fullname = "Ngô Bắp",
                        Email = "phuc@gmail.com"
                    }, 3
                );
            }
        }

        //Test Update User Info method --- TRUE
        [Test]
        [TestCaseSource("LoginFacebookTestCaseTrue")]
        public async Task LoginFacebookTestTrue(User loginUser, int userId)
        {
            //Arrange in TestCaseSource

            //Act
            var user = await _userService.FacebookLogin(loginUser);

            //Assert
            Assert.That(user.UserId, Is.EqualTo(userId));
        }
    }
}