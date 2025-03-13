using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DocEventsAttendanceCalendar.Domain.Interfaces
{
    public interface IAttendeeService
    {
        Task AddAttendeeToEvent(RequestAttendeeDto requestDto);
        Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId);
    }
}
