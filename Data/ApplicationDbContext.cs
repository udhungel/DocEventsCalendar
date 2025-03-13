using DocEventsCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DocEventsCalendar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<EventAttendee> EventAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventAttendee>()
                .HasKey(ea => new { ea.AttendeeId, ea.EventId }); // Composite key
            modelBuilder.Entity<EventAttendee>()
                .HasOne(ea => ea.Attendee)
                .WithMany(a => a.EventAttendances)
                .HasForeignKey(ea => ea.AttendeeId);
            modelBuilder.Entity<EventAttendee>()
                .HasOne(ea => ea.Event)
                .WithMany(e => e.EventAttendances)
                .HasForeignKey(ea => ea.EventId);
            modelBuilder.Entity<Attendee>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Attendee>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(36); 
            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(24); 
            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .HasMaxLength(100);
            modelBuilder.Entity<Event>()
                .Property(e => e.StartTime)
                .HasDefaultValueSql("GETDATE()"); // Default contraint
            modelBuilder.Entity<Event>()
                .Property(e => e.EndTime)
                .HasDefaultValueSql("GETDATE()");           
        }
    }
}
