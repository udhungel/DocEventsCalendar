namespace DocEventsAttendeeCalendar.DTOs
{
    public class RequestAttendeeDto
    {
        public int EventId { get; set; } 
        public int AttendeeId { get; set; } 
        public bool IsAttending { get; set; } 
    }
}
