using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using DocEventsCalendar.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DocEventsAttendanceCalendar.Domain.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IEventRepository _eventRepository;
        public AttendeeService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task AddAttendeeToEvent(RequestAttendeeDto requestDto)
        {           
            await _eventRepository.AddAttendeeToEvent(requestDto.EventId, requestDto.AttendeeId);
        }
        public async Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {           
           return await _eventRepository.RemoveAttendeeFromEvent(eventId, attendeeId);
           
        }
    }
}
