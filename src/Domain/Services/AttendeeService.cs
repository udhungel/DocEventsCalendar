using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
namespace DoctorCalendarAPI.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;
        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }
        public async Task<ResponseAttendeeDto> CreateAttendee(RequestAttendeeDto requestAttendeeDto)
        {
            var attendee = new Attendee
            {
                Name = requestAttendeeDto.Name,
                Email = requestAttendeeDto.Email
            };
            await _attendeeRepository.CreateAttendee(attendee);
            
            return new ResponseAttendeeDto
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email
            };
        }

        public async Task<List<ResponseAttendeeDto>> GetAllAttendees()
        {
            var attendees = await _attendeeRepository.GetAllAttendees();
            return attendees.Select(a => new ResponseAttendeeDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email
            }).ToList();
        }
       
    }
}