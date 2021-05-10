using Moq;
using MyFirstApi.Services;
using NUnit.Framework;

namespace MyFirstApi.Tests
{
    public class AppUserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGetMemberAsyncCalled_UserIsMappedToMemberDTO()
        {
            var mockRepo = new Mock<IAppUserService>();
            var service = new AppUserService(mockRepo.Object);
        }
    }
}