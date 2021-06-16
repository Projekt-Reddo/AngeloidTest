using System.Collections.Generic;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class HomeServiceTest
    {
        protected Context _context;
        private ISeasonService _seasonService;
        private ICharacterService _characterService;
        private ITagService _tagService;
        protected IHomePageService _homePageService;

        //Fake data in memory
        List<Season> seasonList = new List<Season>()
        {
            new Season {

            }
        };
        List<Character> characterList = new List<Character>()
        {
            new Character {

            }
        };
        List<Tag> tagList = new List<Tag>()
        {
            new Tag {

            }
        };
        List<Anime> animeList = new List<Anime>() {
            new Anime {

            }
        };

        [SetUp]
        public void Setup()
        {
            //Create option for Fake DB
            var option = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "angeloid").Options;

            //Add Fake DB to context, service
            _context = new Context(option);
            _homePageService = new AnimeService(_context, _seasonService, _characterService, _tagService);

            //Add Fake data to Context
            _context.Seasons.AddRange(seasonList);
            _context.Characters.AddRange(characterList);
            _context.Tags.AddRange(tagList);
            _context.Animes.AddRange(animeList);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            //Remove Fake DB to re-insert
            _context.Seasons.RemoveRange(seasonList);
            _context.Characters.RemoveRange(characterList);
            _context.Tags.RemoveRange(tagList);
            _context.Animes.RemoveRange(animeList);
            _context.SaveChanges();
        }
    }
}