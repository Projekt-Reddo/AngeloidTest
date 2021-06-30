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
                ThreadId = 1,
                Title = "Thread 1",
                Content = "Thread 1 Content",
                Image = null,
                UserId = 1
            },
            new Thread {
                ThreadId = 2,
                Title = "Thread 2",
                Content = "Thread 2 Content",
                Image = null,
                UserId = 2
            }
        };
         List<User> userList = new List<User>() {
            new User {
                UserId = 1,
                FacebookId = "12345",
                UserName = "hostcode0301",
                Password = "12345678",
                Fullname = "Tran Thien Phu",
                Email = "hostcode0301@gmail.com",
                Gender = "Male",
                Avatar = {},
                IsAdmin = true
            },
            new User {
                UserId = 2,
                FacebookId = "23456",
                UserName = "BaoLoc",
                Password = "admin",
                Fullname = "Pham Bao Loc",
                Email = "Baoloc@gmail.com",
                Gender = "Male",
                Avatar = null,
                IsAdmin = false
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
            _context.Users.AddRange(userList);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            //Remove Fake DB to re-insert
            _context.Threads.RemoveRange(_context.Threads);
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }
    }
}