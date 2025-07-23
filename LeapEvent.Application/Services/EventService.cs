using LeapEvent.Application.Interfaces;
using LeapEvent.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly ILogger<EventService> _logger;

        public EventService(IEventRepository repository, ILogger<EventService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<EventEntity>> GetUpcomingEventsAsync(int days)
        {
            try
            {
                if (days != 30 && days != 60 && days != 180)
                    throw new ArgumentException("Invalid days range. Allowed: 30, 60, or 180");
                _logger.LogInformation("Fetching upcoming events for next {days} days", days);
                return await _repository.GetUpcomingEventsAsync(days);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetUpcomingEventsAsync");
                throw;
            }
        }
    }
}
