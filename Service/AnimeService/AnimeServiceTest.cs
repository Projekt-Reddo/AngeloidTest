using System;
using System.Collections.Generic;
using System.Text;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class AnimeServiceTest
    {
        protected Context _context;
        private IStudioService _studioService;
        private ISeasonService _seasonService;
        private ICharacterService _characterService;
        private ITagService _tagService;
        private ISeiyuuService _seiyuuService;
        protected IAnimeService _animeService;

        //Fake data in memory
        List<Season> seasonList = new List<Season>()
        {
            new Season {
                SeasonId = 1,
                Year = "1992",
                SeasonName = "Spring"
            },
            new Season {
                SeasonId = 2,
                Year = "2020",
                SeasonName = "Summer"
            },
            new Season {
                SeasonId = 3,
                Year = "2015",
                SeasonName = "Fall"
            },
            new Season {
                SeasonId = 4,
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
                CharacterImage = getRandomBytes(),
                SeiyuuId = 31,
                AnimeId = 17
            },
            new Character {
                CharacterId = 34,
                CharacterName = "Ibara Mayaka",
                CharacterRole = "Main",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 32,
                AnimeId = 17
            },
            new Character {
                CharacterId = 72,
                CharacterName = "Tomori Nao",
                CharacterRole = "Supporting",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 68,
                AnimeId = 29
            },
            new Character {
                CharacterId = 73,
                CharacterName = "Otosaka Yuu",
                CharacterRole = "Supporting",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 69,
                AnimeId = 29,

            },
            new Character {
                CharacterId = 111,
                CharacterName = "Sakurajima Mai",
                CharacterRole = "Main",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 94,
                AnimeId = 39
            },
            new Character {
                CharacterId = 113,
                CharacterName = "Futaba Rio",
                CharacterRole = "Supporting",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 96,
                AnimeId = 39
            },
            new Character {
                CharacterId = 114,
                CharacterName = "Koga Tomoe",
                CharacterRole = "Supporting",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 97,
                AnimeId = 39
            },
            new Character {
                CharacterId = 115,
                CharacterName = "Azusagawa Kaede",
                CharacterRole = "Supporting",
                CharacterImage = getRandomBytes(),
                SeiyuuId = 98,
                AnimeId = 39
            },
        };

        List<Seiyuu> seiyuuList = new List<Seiyuu>()
        {
            new Seiyuu{
                SeiyuuId = 31,
                SeiyuuName = "Satou Satomi",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 32,
                SeiyuuName = "Kayano Ai",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 68,
                SeiyuuName = "Sakura Ayane",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 69,
                SeiyuuName = "Uchiyama Kouki",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 94,
                SeiyuuName = "Seto Asami",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 96,
                SeiyuuName = "Tanezaki Atsumi",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 97,
                SeiyuuName = "Touyama Nao",
                SeiyuuImage = getRandomBytes(),
            },
            new Seiyuu{
                SeiyuuId = 98,
                SeiyuuName = "Kubo Yurika",
                SeiyuuImage = getRandomBytes(),
            },
        };

        List<Tag> tagList = new List<Tag>()
        {
            new Tag {
                TagId = 1,
                TagName = "Slice Of Life",
                TagDescription = ""
            },
            new Tag {
                TagId = 2,
                TagName = "Drama",
                TagDescription = ""
            },
            new Tag {
                TagId = 3,
                TagName = "Romance",
                TagDescription = ""
            },
        };

        List<AnimeTag> animeTagList = new List<AnimeTag>()
        {
            new AnimeTag
            {
                AnimeId = 17,
                TagId = 1
            },
            new AnimeTag
            {
                AnimeId = 17,
                TagId = 3
            },
            new AnimeTag
            {
                AnimeId = 29,
                TagId = 2
            },
            new AnimeTag
            {
                AnimeId = 29,
                TagId = 3
            },
            new AnimeTag
            {
                AnimeId = 39,
                TagId = 1
            },
            new AnimeTag
            {
                AnimeId = 39,
                TagId = 2
            },
            new AnimeTag
            {
                AnimeId = 39,
                TagId = 3
            },
        };

        List<Anime> animeList = new List<Anime>() {
            new Anime
            {
                AnimeId = 17,
                AnimeName = "Hyouka",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/N5nNKAVB4O4?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1032178,
                EpisodeDuration = "25 min per ep",
                Episode = "22",
                StartDay = "Apr 23, 2012",
                Web = "https://myanimelist.net/anime/12189/Hyouka",
                SeasonId = 1,
                StudioId = 16,
            },
            new Anime
            {
                AnimeId = 29,
                AnimeName = "Charlotte",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/6AgEzww-a0w?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1174381,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Jul 5, 2015",
                Web = "https://myanimelist.net/anime/28999/Charlotte",
                SeasonId = 3,
                StudioId = 16,
            },
            
            new Anime
            {
                AnimeId = 39,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 40,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 41,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 42,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 43,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 44,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 45,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
            new Anime
            {
                AnimeId = 46,
                AnimeName = "Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai",
                Content = "La la la la la",
                Thumbnail = getRandomBytes(),
                Status = "Finished Airing",
                Wallpaper = getRandomBytes(),
                Trailer = "https://www.youtube.com/embed/ku7XxxXpIKI?enablejsapi=1&wmode=opaque&autoplay=1",
                View = 1119830,
                EpisodeDuration = "24 min per ep",
                Episode = "13",
                StartDay = "Oct 4, 2018",
                Web = "https://myanimelist.net/anime/37450/Seishun_Buta_Yarou_wa_Bunny_Girl_Senpai_no_Yume_wo_Minai",
                SeasonId = 4,
                StudioId = 132,
            },
        };

        protected static byte[] getRandomBytes() {
            // Put random bytes into this array.
            byte[] array = new byte[2000000];
            // Fill array with random bytes.
            Random random = new Random();
            random.NextBytes(array);
            return array;
        }

        [SetUp]
        public void Setup()
        {
            //Create option for Fake DB
            var option = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "angeloid").Options;

            //Add Fake DB to context, service
            _context = new Context(option);
            _seiyuuService = new SeiyuuService(_context);
            _characterService = new CharacterService(_context, _seiyuuService);
            _seasonService = new SeasonService(_context);
            _tagService = new TagService(_context);
            _animeService = new AnimeService(_context, _seasonService, _characterService, _tagService);

            _context.AddRange(studioList);
            _context.Studios.AddRange(studioList);
            _context.AddRange(seasonList);
            _context.AddRange(tagList);
            _context.AddRange(animeTagList);
            _context.AddRange(animeList);
            _context.AddRange(seiyuuList);
            _context.AddRange(characterList);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            // _context.RemoveRange(_context.AnimeTags);
            _context.RemoveRange(_context.Tags);
            _context.RemoveRange(_context.Animes);
            _context.RemoveRange(_context.Seiyuus);
            _context.RemoveRange(_context.Seasons);
            _context.RemoveRange(_context.Studios);
            _context.RemoveRange(_context.Characters);
            _context.SaveChanges();
        }
    }
}