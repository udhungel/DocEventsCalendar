﻿namespace DocEventsAttendeeCalendar.DTOs
{
    public class RequestEventDto
    {       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
