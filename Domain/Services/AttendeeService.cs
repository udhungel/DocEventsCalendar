using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsCalendar.Domain.Interfaces;

namespace DocEventsAttendanceCalendar.Domain.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IEventRepository _eventRepository;
        public AttendeeService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task AddAttendeeToEvent(int eventId, int attendeeId)
        {
            await _eventRepository.AddAttendeeToEvent(eventId, attendeeId);
        }
        public async Task RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {
            await _eventRepository.RemoveAttendeeFromEvent(eventId, attendeeId);
        }
    }
}
