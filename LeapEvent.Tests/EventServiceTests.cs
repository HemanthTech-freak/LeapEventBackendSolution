using LeapEvent.Application.Interfaces;
using LeapEvent.Application.Services;
using LeapEvent.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LeapEvent.Tests
{
    [TestClass]
    public class EventServiceTests
    {
        private Mock<IEventRepository> _mockRepo;
        private Mock<ILogger<EventService>> _mockLogger;
        private EventService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IEventRepository>();
            _mockLogger = new Mock<ILogger<EventService>>();
            _service = new EventService(_mockRepo.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task GetUpcomingEventsAsync_WithValidDays_ReturnsEvents()
        {
            // Arrange
            var mockEvents = new List<EventEntity> { new EventEntity { Id = "1", Name = "Rogers mall event" } };
            _mockRepo.Setup(r => r.GetUpcomingEventsAsync(30)).ReturnsAsync(mockEvents);

            // Act
            var result = await _service.GetUpcomingEventsAsync(30);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Rogers mall event", result[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetUpcomingEventsAsync_WithInvalidDays_ThrowsException()
        {
            // Act
            await _service.GetUpcomingEventsAsync(15);
        }

        [TestMethod]
        public async Task GetUpcomingEventsAsync_WhenRepositoryThrows_ThrowsException()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetUpcomingEventsAsync(It.IsAny<int>()))
                     .ThrowsAsync(new Exception("DB error"));

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await _service.GetUpcomingEventsAsync(30);
            });

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once
            );
        }
    }
}
