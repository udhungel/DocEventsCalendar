using DocEventsCalendar.Data;
using DocEventsCalendar.Domain.Entities;
using DocEventsCalendar.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocEventsCalendar.Domain.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {           
            _context = context;
        }       

        public async Task<Event> CreateEvent(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
            return @event;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null)
                return false;
            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.Events.Include(e => e.EventAttendances)
                                        .ThenInclude(ea => ea.Attendee)
                                        .ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.Include(e => e.EventAttendances)
                                        .ThenInclude(ea => ea.Attendee)
                                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> UpdateEvent(Event @event)
        {
            _context.Events.Update(@event);
            await _context.SaveChangesAsync();
            return @event;
        }

        public async Task AddAttendeeToEvent(int eventId, int attendeeId)
        {
            var eventAttendee = new EventAttendee
            {
                EventId = eventId,
                AttendeeId = attendeeId,
                IsAttending = true
            };
            await _context.EventAttendances.AddAsync(eventAttendee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {
            var eventAttendee = await _context.EventAttendances
                .FirstOrDefaultAsync(ea => ea.EventId == eventId && ea.AttendeeId == attendeeId);

            if (eventAttendee != null)
            {
                _context.EventAttendances.Remove(eventAttendee);
                await _context.SaveChangesAsync();
                return true; 
            }
            return false; 
        }

       
    }
}
