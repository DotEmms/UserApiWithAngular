using AutoMapper;
using Moq;
using MyFirstApi.Helpers;
using MyFirstApi.Repositories;
using MyFirstApi.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Tests
{
    public class AppUserServiceTests
    {
        private Mock<IAppUserRepository> mockRepo;
        private MapperConfiguration config;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IAppUserRepository>();
            config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
        }

        [Test]
        public async Task WhenGetMemberAsyncCalled_UserIsMappedToMemberDTOAsync()
        {
            //ARRANGE
            //mock a dependency
            //var mockRepo = new Mock<IAppUserRepository>();

            AppUser fakeUser = new AppUser
            {
                City = "FakeTown",
                CountryOfOrigin = "FakeCountry",
                Gender = "Fake",
                Interests = "Fake it",
                Name = "Faker McGee",
                DateOfBirth = new System.DateTime(1969, 4, 20)
            };

            //Fake the return value of a mock dependency
            mockRepo.Setup(x => x.GetUserAsync(It.IsAny<int>())).ReturnsAsync(fakeUser);

            //initialize AutoMapper for Unit Tests
            //var config = new MapperConfiguration(x =>
            //x.AddProfile<AutoMapperProfile>());

            //inject fake dependencies and automapper
            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            //ACT
            var result = await service.GetMemberAsync(1);

            //ASSERT
            Assert.NotNull(result);
            Assert.AreEqual("FakeTown", result.City);
        }

        [Test]
        public async Task WhenGetUsersAsyncCalled_ReturnsListOfUsers()
        {
            //ARRANGE
            List<AppUser> users = new List<AppUser>
            {
                 new AppUser
                {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                 new AppUser {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    City = "FakeTown",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
            };

            mockRepo.Setup(x => x.GetUsersAsync()).ReturnsAsync(users);

            var service = new AppUserService(mockRepo.Object, config.CreateMapper());
            //ACT
            var result = await service.GetUsersAsync();
            //ASSERT
            Assert.NotNull(result);
        }

        [TestCase(1)]
        [TestCase(3)]
        public async Task WhenGetUserAsyncCalled_ReturnsAuser(int id)
        {
            //ARRANGE
            List<AppUser> users = new List<AppUser>
            {
                 new AppUser
                {
                    Id = 1,
                    City = "Alabama",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                 new AppUser {
                    Id = 2,
                    City = "Washington DC",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    Id = 3,
                    City = "Berlin",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    Id = 4,
                    City = "Vienna",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    Id = 5,
                    City = "Paris",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
                new AppUser
                {
                    Id = 6,
                    City = "Boston",
                    CountryOfOrigin = "FakeCountry",
                    Gender = "Fake",
                    Interests = "Fake it",
                    Name = "Faker McGee",
                    DateOfBirth = new System.DateTime(1969, 4, 20)
                },
            };

            mockRepo.Setup(x => x.GetUserAsync(It.IsAny<int>())).ReturnsAsync(users[2]);

            var service = new AppUserService(mockRepo.Object, config.CreateMapper());
            //ACT
            var result = await service.GetUserAsync(id);
            //ASSERT
            Assert.NotNull(result);
            Assert.AreEqual("Berlin", users[2].City);
        }
    }
}