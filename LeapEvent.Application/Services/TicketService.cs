using LeapEvent.Application.Interfaces;
using LeapEvent.Domain.DTOs;
using LeapEvent.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        private readonly ILogger<TicketService> _logger;

        public TicketService(ITicketRepository repo, ILogger<TicketService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<List<TicketSaleEntity>> GetTicketsByEventIdAsync(string eventId)
        {
            _logger.LogInformation("Getting tickets for event {eventId}", eventId);
            return await _repo.GetByEventIdAsync(eventId);
        }

        public async Task<List<EventSalesDto>> GetTop5EventsByTicketsSoldAsync()
        {
            _logger.LogInformation("Getting top 5 events by ticket count");
            return await _repo.GetTop5ByTicketsSoldAsync();
        }

        public async Task<List<EventSalesDto>> GetTop5EventsByTotalRevenueAsync()
        {
            _logger.LogInformation("Getting top 5 events by revenue");
            return await _repo.GetTop5ByRevenueAsync();
        }
    }
}
