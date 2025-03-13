using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendanceCalendar.Domain.Services;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DocEventsAttendeeCalendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IAttendeeService _attendeeService;
        public EventsController(IEventService eventService , IAttendeeService attendeeService)
        {
            _eventService = eventService;
            _attendeeService = attendeeService; 
        }
   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseEventDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEvent(RequestEventDto requestEventDto)
        {
            var createdEvent = await _eventService.CreateEvent(requestEventDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseEventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var updatedEvent = await _eventService.UpdateEvent(id);
            if (updatedEvent == null) return NotFound();
            return Ok(updatedEvent);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ResponseEventDto>))]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseEventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById(int id)
        {
            var events = await _eventService.GetEventById(id);
            if (events == null) 
                return NotFound();
            return Ok(events);
        }        
    }

}

