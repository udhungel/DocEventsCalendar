using DocEventsCalendar.Domain.Interfaces;
using DocEventsCalendar.Domain.Entities;
using DocEventsAttendanceCalendar.Domain.Interfaces;

namespace DocEventsCalendar.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> CreateEvent(Event @event)
        {
            return await _eventRepository.CreateEvent(@event);
        }
        public async Task<Event> UpdateEvent(Event @event)
        {
            return await _eventRepository.UpdateEvent(@event);
        }
        public async Task<bool> DeleteEvent(int id)
        {
            return await _eventRepository.DeleteEvent(id);
        }
        public async Task<List<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }
        public async Task<Event> GetEventById(int id)
        {
            return await _eventRepository.GetEventById(id);
        }
    }
}
