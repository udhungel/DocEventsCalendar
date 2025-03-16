using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendanceCalendar.Domain.Services;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using DocEventsCalendar.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocEventsAttendeeCalendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IAttendeeService _attendeeService;
        private readonly IEventRepository _eventRepository;
        public EventsController(IEventService eventService , IAttendeeService attendeeService, IEventRepository eventRepository)
        {
            _eventService = eventService;
            _attendeeService = attendeeService; 
            _eventRepository = eventRepository;
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
        public async Task<IActionResult> UpdateEvent(int id, UpdateRequestDto updateRequestDto)
        {
            var existingEvent = await _eventRepository.GetEventById(id);

            if (existingEvent == null)
            {
                return null; 
            }
            existingEvent.Title = updateRequestDto.Title;
            existingEvent.Description = updateRequestDto.Description;
            var updatedEvent = await _eventService.UpdateEvent(existingEvent);
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

