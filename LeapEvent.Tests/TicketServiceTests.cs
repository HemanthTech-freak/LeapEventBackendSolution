using LeapEvent.Application.Interfaces;
using LeapEvent.Application.Services;
using LeapEvent.Domain.DTOs;
using LeapEvent.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LeapEvent.Tests
{
    [TestClass]
    public class TicketServiceTests
    {
        private Mock<ITicketRepository> _mockRepo;
        private Mock<ILogger<TicketService>> _mockLogger;
        private TicketService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<ITicketRepository>();
            _mockLogger = new Mock<ILogger<TicketService>>();
            _service = new TicketService(_mockRepo.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task GetTicketsByEventIdAsync_ValidId_ReturnsTickets()
        {
            var eventId = "toronto_rogers";
            var mockTickets = new List<TicketSaleEntity> { new TicketSaleEntity { Id = "t1", EventId = eventId } };

            _mockRepo.Setup(r => r.GetByEventIdAsync(eventId)).ReturnsAsync(mockTickets);

            var result = await _service.GetTicketsByEventIdAsync(eventId);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("toronto_rogers", result[0].EventId);
        }

        [TestMethod]
        public async Task GetTop5EventsByTicketsSoldAsync_ReturnsDtos()
        {
            var mockData = new List<EventSalesDto> {
                new EventSalesDto { EventId = "1", EventName = "E1", TicketsSold = 100, TotalRevenue = 500 }
            };

            _mockRepo.Setup(r => r.GetTop5ByTicketsSoldAsync()).ReturnsAsync(mockData);

            var result = await _service.GetTop5EventsByTicketsSoldAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("E1", result[0].EventName);
        }

        [TestMethod]
        public async Task GetTop5EventsByTotalRevenueAsync_ReturnsDtos()
        {
            var mockData = new List<EventSalesDto> {
                new EventSalesDto { EventId = "2", EventName = "E2", TicketsSold = 80, TotalRevenue = 1000 }
            };

            _mockRepo.Setup(r => r.GetTop5ByRevenueAsync()).ReturnsAsync(mockData);

            var result = await _service.GetTop5EventsByTotalRevenueAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1000, result[0].TotalRevenue);
        }
    }
}
