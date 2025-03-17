using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace DoctorCalendarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventAttendeeController : ControllerBase
    {
        private readonly IEventAttendeeService _eventAttendeeService;
        public EventAttendeeController(IEventAttendeeService eventAttendeeService)
        {
            _eventAttendeeService = eventAttendeeService;
        }
       
        [HttpPost]       
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventAttendee(CreateEventAttendeeRequest request)
        {
            var eventAttendee = await _eventAttendeeService.CreateEventAttendee(request);
            return CreatedAtAction(nameof(GetAttendeesByEventId), new { eventId = request.EventId }, eventAttendee);
        }

        [HttpGet("{eventId:int}/attendees")]
        [ProducesResponseType(typeof(List<EventAttendeeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAttendeesByEventId(int eventId)
        {
            var attendees = await _eventAttendeeService.GetAttendeesByEventId(eventId);
            return Ok(attendees);
        }
       
        [HttpGet("attendee/{attendeeId:int}/events")]
        [ProducesResponseType(typeof(List<EventAttendeeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventsByAttendeeId(int attendeeId)
        {
            var events = await _eventAttendeeService.GetEventsByAttendeeId(attendeeId);
            return Ok(events);
        }
    }
}