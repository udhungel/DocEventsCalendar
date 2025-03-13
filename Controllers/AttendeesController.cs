using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendanceCalendar.Domain.Services;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocEventsAttendeeCalendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;
        public AttendeesController(IAttendeeService attendeeService)
        {
         _attendeeService = attendeeService; 
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RequestAttendeeDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AddAttendeeToEvent(RequestAttendeeDto requestAttendeeDto)
        {
            await _attendeeService.AddAttendeeToEvent(requestAttendeeDto);
            return NoContent();
        }

        [HttpDelete("{eventId}/attendees/{attendeeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] // Successful removal
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Not found
        public async Task<IActionResult> RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {
            var result = await _attendeeService.RemoveAttendeeFromEvent(eventId, attendeeId);
            if (result)
            {
                return NoContent(); 
            }
            else
            {
                return NotFound(); 
            }
        }
    }
}
