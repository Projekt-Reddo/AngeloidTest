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
    public class GetAllAnimeTest : AnimeServiceTest
    {
        //Test Update User Info method --- TRUE
        [Test, Timeout(2000)]
        public async Task LoginTestTrue()
        {
            //Arrange in TestCaseSource

            //Act
            var animeList = await _animeService.ListAllAnime();

            //Assert
            Assert.That(animeList.Count, Is.EqualTo(10));
        }
    }
}