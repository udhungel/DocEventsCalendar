namespace DocEventsAttendeeCalendar.DTOs
{
    public class CreateEventAttendeeRequest
    {
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
        public bool IsAttending { get; set; }
    }
}
