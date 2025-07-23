using LeapEvent.Domain.DTOs;
using LeapEvent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<TicketSaleEntity>> GetByEventIdAsync(string eventId);
        Task<List<EventSalesDto>> GetTop5ByTicketsSoldAsync();
        Task<List<EventSalesDto>> GetTop5ByRevenueAsync();
    }
}
