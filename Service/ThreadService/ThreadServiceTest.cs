using System.Collections.Generic;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class ThreadServiceTest
    {
        protected Context _context;
        protected IThreadService _threadService;

        //Fake data in memory
        List<Thread> threadList = new List<Thread>() {
            new Thread {

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
            _threadService = new ThreadService(_context);

            //Add Fake data to Context
            _context.Threads.AddRange(threadList);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            //Remove Fake DB to re-insert
            _context.Threads.RemoveRange(threadList);
            _context.SaveChanges();
        }
    }
}