using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsCalendar.Data;
using DocEventsCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DoctorCalendarAPI.Repositories
{
    public class EventAttendeeRepository : IEventAttendeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EventAttendeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }      

         
        public async Task<List<EventAttendee>> GetAttendeesByEventId(int eventId)
        {
            return await _context.EventAttendances.Where(ea => ea.EventId == eventId)
                .Include(ea => ea.Attendee)
                .Include(ea => ea.Event)               
                .ToListAsync();
        }
        public async Task<List<EventAttendee>> GetEventsByAttendeeId(int attendeeId) 
        {
           return await _context.EventAttendances.Where(x=>x.AttendeeId == attendeeId)            
            .Include(ea => ea.Event) 
            .Include(e => e.Attendee)            
            .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int eventId, int attendeeId)
        {
            var result = await _context.EventAttendances
                .AnyAsync(e => e.AttendeeId == attendeeId
                             && e.EventId == eventId);

            return result; 
        }

        public async Task<EventAttendee> CreateEventAttendee(int eventId, int attendeeId)
        {
            if (await ExistsAsync(eventId, attendeeId))
            {
                throw new InvalidOperationException("This attendee is already associated with the event.");
            }
            var eventAttendee = new EventAttendee
            {
                EventId = eventId,
                AttendeeId = attendeeId,
                IsAttending = true
            };
            await _context.EventAttendances.AddAsync(eventAttendee);
            await _context.SaveChangesAsync();
            return eventAttendee;
        }

      
    }
}