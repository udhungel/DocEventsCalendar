using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DocEventsAttendanceCalendar.Domain.Interfaces
{
    public interface IAttendeeService
    {
        Task<ResponseAttendeeDto> CreateAttendee(RequestAttendeeDto attendee);
       
        Task<List<ResponseAttendeeDto>> GetAllAttendees();
    }
}
