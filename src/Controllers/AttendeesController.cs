using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace DoctorCalendarAPI.Controllers
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
        public async Task<IActionResult> CreateAttendee(RequestAttendeeDto reqAttendeeDto)
        {
            if (reqAttendeeDto == null || string.IsNullOrWhiteSpace(reqAttendeeDto.Name) || string.IsNullOrWhiteSpace(reqAttendeeDto.Email))
            {
                return BadRequest("Attendee data is not invalid.");
            }
            var createdAttendee = await _attendeeService.CreateAttendee(reqAttendeeDto);
            return CreatedAtAction(nameof(GetAllAttendees), new { id = createdAttendee.Id }, createdAttendee);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllAttendees()
        {
            var attendees = await _attendeeService.GetAllAttendees();
            return Ok(attendees);
        }
    }
}