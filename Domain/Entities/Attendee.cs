namespace DocEventsCalendar.Domain.Entities
{
    public class Attendee
    {
        public int Id { get; set; }        
        public string Name { get; set; }       
        public string Email { get; set; }

        public List<EventAttendee> EventAttendances { get; set; } = new List<EventAttendee>();
    }
}
