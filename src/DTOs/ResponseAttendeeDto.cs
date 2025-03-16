namespace DocEventsAttendeeCalendar.DTOs
{
    public class ResponseAttendeeDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAttending { get; set; }
    }
}
