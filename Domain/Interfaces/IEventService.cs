using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;

namespace DocEventsAttendanceCalendar.Domain.Interfaces
{
    public interface IEventService
    {
        Task<ResponseEventDto> CreateEvent(RequestEventDto requestEventDto);
        Task<ResponseEventDto> UpdateEvent(Event events);
        Task<bool> DeleteEvent(int id);
        Task<List<ResponseEventDto>> GetAllEvents();
        Task<ResponseEventDto> GetEventById(int id);
        
    }
}
