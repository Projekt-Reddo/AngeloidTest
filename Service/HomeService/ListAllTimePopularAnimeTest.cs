using System.Collections.Generic;
using System.Threading.Tasks;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class ListAllTimePopularAnimeTest : HomeServiceTest
    {
        //Test List All Time Popular Anime method
        [Test]
        public async Task ListAllTimePopularAnimeTestTrue()
        {
            //Arrange in TestCaseSource

            //Act
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var rs = await _homePageService.ListAllTimePopularAnime();
            watch.Stop();

            //Assert
            Assert.That(watch.ElapsedMilliseconds, Is.LessThan(1000));
        }
    }
}