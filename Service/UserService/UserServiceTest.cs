using System.Collections.Generic;
using Angeloid.DataContext;
using Angeloid.Models;
using Angeloid.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AngeloidTest
{
    [TestFixture]
    public class UserServiceTest
    {
        protected Context _context;
        protected IUserService _userService;

        //Fake data in memory
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
            },
            new User {
                UserId = 3,
                FacebookId = "34567",
                UserName = "LoliCorn",
                Password = "admin",
                Fullname = "Ngo Nguyen Hoang Phuc",
                Email = "phuc@gmail.com",
                Gender = "Male",
                Avatar = null,
                IsAdmin = true
            },
            new User {
                UserId = 4,
                FacebookId = "23456",
                UserName = "HoangVi",
                Password = "12345678",
                Fullname = "Nguyen Hoang Vi",
                Email = "Vi@gmail.com",
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
            _userService = new UserService(_context);

            //Add Fake data to Context
            _context.Users.AddRange(userList);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            //Remove Fake DB to re-insert
            _context.Users.RemoveRange(userList);
            _context.SaveChanges();
        }
    }
}