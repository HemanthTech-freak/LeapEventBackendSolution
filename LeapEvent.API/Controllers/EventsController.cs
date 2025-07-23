using LeapEvent.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeapEvent.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //Get events controller to fetch events with days 30, 60, or 180
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int days = 30)
        {
            var validDays = new[] { 30, 60, 180 };
            if (!validDays.Contains(days))
                return BadRequest(new
                {
                    Message = "Only 30, 60, or 180 days are allowed."
                });
            var result = await _eventService.GetUpcomingEventsAsync(days);
            return Ok(result);
        }
    }
}
