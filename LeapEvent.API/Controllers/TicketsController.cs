using LeapEvent.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeapEvent.API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        //Get ticekts by event controller 
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetByEvent(string eventId)
        {
            var tickets = await _service.GetTicketsByEventIdAsync(eventId);
            return Ok(tickets);
        }

        //Get top 5 events by ticket sales 
        [HttpGet("top-by-sales")]
        public async Task<IActionResult> TopByTicketSales()
        {
            var top = await _service.GetTop5EventsByTicketsSoldAsync();
            return Ok(top);
        }

        //Get top 5 events by revenue
        [HttpGet("top-by-revenue")]
        public async Task<IActionResult> TopByRevenue()
        {
            var top = await _service.GetTop5EventsByTotalRevenueAsync();
            return Ok(top);
        }
    }
}
