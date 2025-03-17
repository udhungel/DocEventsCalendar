using DocEventsCalendar.Domain.Entities;

namespace DocEventsAttendeeCalendar.Domain.Interfaces
{
    public interface IAttendeeRepository
    {
        Task<Attendee> CreateAttendee(Attendee attendee);
        Task<List<Attendee>> GetAllAttendees();
    
     
    }
}
