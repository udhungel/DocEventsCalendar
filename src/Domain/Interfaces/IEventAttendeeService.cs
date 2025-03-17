using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;

namespace DocEventsAttendeeCalendar.Domain.Interfaces
{
    public interface IEventAttendeeService
    {
        Task<CreateEventAttendeeResponse> CreateEventAttendee(CreateEventAttendeeRequest request);
        Task<List<EventAttendeeResponse>> GetAttendeesByEventId(int eventId);
        Task<List<EventAttendeeResponse>> GetEventsByAttendeeId(int attendeeId);
    }
}

