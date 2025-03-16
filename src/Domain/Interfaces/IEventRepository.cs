using DocEventsCalendar.Domain.Entities;

namespace DocEventsCalendar.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int id);
        Task<Event> CreateEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        Task<bool> DeleteEvent(int id);   
        Task AddAttendeeToEvent(int eventId, int attendeeId);
        Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId);

    }
}
