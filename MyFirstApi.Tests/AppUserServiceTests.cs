using AutoMapper;
using Moq;
using MyFirstApi.Helpers;
using MyFirstApi.Repositories;
using MyFirstApi.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyFirstApi.Tests
{
    public class AppUserServiceTests
    {
        //private Mock<IAppUserRepository> mockRepo;
        //private MapperConfiguration config;
        [SetUp]
        public void Setup()
        {
            //mockRepo = new Mock<IAppUserRepository>();
            //config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());
        }

        [Test]
        public async Task WhenGetMemberAsyncCalled_UserIsMappedToMemberDTOAsync()
        {
            //ARRANGE
            //mock a dependency
            var mockRepo = new Mock<IAppUserRepository>();

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
            var config = new MapperConfiguration(x =>
            x.AddProfile<AutoMapperProfile>());

            //inject fake dependencies and automapper
            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            //ACT
            var result = await service.GetMemberAsync(1);

            //ASSERT
            Assert.NotNull(result);
            Assert.AreEqual("FakeTown", result.City);
        }
    }
}