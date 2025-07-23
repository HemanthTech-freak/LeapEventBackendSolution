using LeapEvent.Domain.DTOs;
using LeapEvent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Application.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketSaleEntity>> GetTicketsByEventIdAsync(string eventId);
        Task<List<EventSalesDto>> GetTop5EventsByTicketsSoldAsync();
        Task<List<EventSalesDto>> GetTop5EventsByTotalRevenueAsync();
    }
}
