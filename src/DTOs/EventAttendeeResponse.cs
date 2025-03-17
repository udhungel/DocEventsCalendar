namespace DocEventsAttendeeCalendar.DTOs
{
    public class EventAttendeeResponse
    {
        public int AttendeeId { get; set; } 
        public string AttendeeName { get; set; } 

        public string AttendeeEmail { get; set; }
        public int EventId { get; set; }    
        public string EventTitle { get; set; } 
        public bool IsAttending { get; set; } 
    }
}
