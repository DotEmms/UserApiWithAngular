using AutoMapper;
using Moq;
using MyFirstApi.Helpers;
using MyFirstApi.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.Tests
{
    class AccountServiceTests
    {
        private Mock<IAccountRepository> mockRepo;
        private MapperConfiguration config;
        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IAccountRepository>();
            config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
        }

        [Test]
        public void DoStuff()
        {

        }
    }
}
