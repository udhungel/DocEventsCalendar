namespace DocEventsCalendar.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //navigation property
        public List<EventAttendee> EventAttendances { get; set; } = new List<EventAttendee>();
    }
}
