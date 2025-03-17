using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsCalendar.Data;
using DocEventsCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocEventsAttendeeCalendar.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Attendee> CreateAttendee(Attendee attendee)
        {
            await _context.Attendees.AddAsync(attendee);
            await _context.SaveChangesAsync();
            return attendee;
        }
      
        public async Task<List<Attendee>> GetAllAttendees()
        {
            return await _context.Attendees.ToListAsync();
        }
     
    }
}
