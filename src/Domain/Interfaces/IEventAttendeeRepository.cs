using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocEventsAttendeeCalendar.Domain.Interfaces
{
    public interface IEventAttendeeRepository
    {
        
        Task<EventAttendee> CreateEventAttendee(int eventId, int attendeeId);
        Task<List<EventAttendee>> GetAttendeesByEventId(int eventId);
        Task<List<EventAttendee>> GetEventsByAttendeeId(int attendeeId);        
    }
}
