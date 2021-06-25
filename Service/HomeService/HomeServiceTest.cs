using System.Collections.Generic;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Text;

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
                SeasonId = 1,
                Year = "1992",
                SeasonName = "Spring"
            },
            new Season {
                SeasonId = 1,
                Year = "2020",
                SeasonName = "Summer"
            },
            new Season {
                SeasonId = 1,
                Year = "2015",
                SeasonName = "Fall"
            },
            new Season {
                SeasonId = 1,
                Year = "2006",
                SeasonName = "Winter"
            },
        };

        List<Studio> studioList = new List<Studio>()
        {
            new Studio{
                StudioId = 2,
                StudioName = "Kyoto Animation"
            },
            new Studio{
                StudioId = 132,
                StudioName = "P.A. Works"
            },
            new Studio{
                StudioId = 16,
                StudioName = "TV Tokyo"
            },
            new Studio{
                StudioId = 15,
                StudioName = "Sony Pictures Entertainment"
            },
        };

        List<Character> characterList = new List<Character>()
        {
            new Character {
                CharacterId = 33,
                CharacterName = "Chitanda Eru",
                CharacterRole = "Main",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 34,
                CharacterName = "Ibara Mayaka",
                CharacterRole = "Main",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 72,
                CharacterName = "Tomori Nao",
                CharacterRole = "Supporting",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 73,
                CharacterName = "Otosaka Yuu",
                CharacterRole = "Supporting",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 111,
                CharacterName = "Sakurajima Mai",
                CharacterRole = "Main",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 113,
                CharacterName = "Futaba Rio",
                CharacterRole = "Supporting",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 114,
                CharacterName = "Koga Tomoe",
                CharacterRole = "Supporting",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
            new Character {
                CharacterId = 115,
                CharacterName = "Azusagawa Kaede",
                CharacterRole = "Supporting",
                CharacterImage = Encoding.ASCII.GetBytes("asdfaw/fawef098asd")
            },
        };
        List<Tag> tagList = new List<Tag>()
        {
            new Tag {
                TagId = 1,
                TagName = "Slice Of Life",
                TagDescription = ""
            },
        };
        List<Anime> animeList = new List<Anime>() {
            new Anime
            {
                AnimeId = 17,
                AnimeName = "Hyouka",
                Content = "La la la la la",
                Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Status = "Finished Airing",
                Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Trailer = "https://www.youtube.com/embed/N5nNKAVB4O4?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1032178,
                EpisodeDuration = "25 min per ep",
                Episode = "22",
                StartDay = "Apr 23, 2012",
                Web = "https://myanimelist.net/anime/12189/Hyouka",
            },
            new Anime
            {
                AnimeId = 29,
                AnimeName = "Charlotte",
                Content = "La la la la la",
                Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Status = "Finished Airing",
                Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Trailer = "https://www.youtube.com/embed/6AgEzww-a0w?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1174381,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Jul 5, 2015",
                Web = "https://myanimelist.net/anime/28999/Charlotte",
            },
            new Anime
            {
                AnimeId = 39,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Status = "Finished Airing",
                Wallpaper = Encoding.ASCII.GetBytes("asdfaw/fawef098asd"),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
            },
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