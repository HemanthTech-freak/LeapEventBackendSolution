using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Domain.DTOs
{
    public class EventSalesDto
    {
        public string EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public int TicketsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
