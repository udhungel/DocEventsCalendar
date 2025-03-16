namespace DocEventsCalendar.Domain.Entities
{
    public class EventAttendee
    {
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsAttending { get; set; } 
    }
}
