using DocEventsCalendar.Domain.Entities;

namespace DocEventsAttendanceCalendar.Domain.Interfaces
{
    public interface IEventService
    {
        Task<Event> CreateEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        Task<bool> DeleteEvent(int id);
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int id);
    }
}
