using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using DocEventsCalendar.Domain.Interfaces;
namespace DoctorCalendarAPI.Services
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private readonly IEventAttendeeRepository _eventAttendeeRepository;
        public EventAttendeeService(IEventAttendeeRepository eventAttendeeRepository)
        {
            _eventAttendeeRepository = eventAttendeeRepository;
        }
        public async Task<CreateEventAttendeeResponse> CreateEventAttendee(CreateEventAttendeeRequest request)
        {
            
            var eventAttendee = new EventAttendee
            {
                AttendeeId = request.AttendeeId,
                EventId = request.EventId,
                IsAttending = request.IsAttending
            };
            
            await _eventAttendeeRepository.CreateEventAttendee(request.EventId, request.AttendeeId);
            
            return new CreateEventAttendeeResponse
            {
                AttendeeId = eventAttendee.AttendeeId,
                EventId = eventAttendee.EventId,
                IsAttending = eventAttendee.IsAttending             
            };
        }
        public async Task<List<EventAttendeeResponse>> GetAttendeesByEventId(int eventId)
        {
            var eventAttendances = await _eventAttendeeRepository.GetAttendeesByEventId(eventId);
            return eventAttendances.Select(ea => new EventAttendeeResponse
            {
                AttendeeId = ea.AttendeeId,
                EventId = ea.EventId,
                IsAttending = ea.IsAttending,
                AttendeeName = ea.Attendee?.Name, 
                AttendeeEmail = ea.Attendee?.Email,
                EventTitle = ea.Event?.Title 
            }).ToList();
        }
        public async Task<List<EventAttendeeResponse>> GetEventsByAttendeeId(int attendeeId)
        {
            var eventAttendances = await _eventAttendeeRepository.GetEventsByAttendeeId(attendeeId); 
            
            
            return eventAttendances.Select(ea => new EventAttendeeResponse
            {
                AttendeeId = ea.AttendeeId,
                EventId = ea.EventId,
                IsAttending = ea.IsAttending,
              
                AttendeeName = ea.Attendee?.Name,
                AttendeeEmail = ea.Attendee?.Email,
                EventTitle = ea.Event?.Title
            }).ToList();
        }
    }
}