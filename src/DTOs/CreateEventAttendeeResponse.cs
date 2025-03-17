namespace DocEventsAttendeeCalendar.DTOs
{
    public class CreateEventAttendeeResponse
    {
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
        public bool IsAttending { get; set; }
    }
}
