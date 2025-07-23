using LeapEvent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Application.Interfaces
{
    public interface IEventService
    {
        Task<List<EventEntity>> GetUpcomingEventsAsync(int days);
    }
}
