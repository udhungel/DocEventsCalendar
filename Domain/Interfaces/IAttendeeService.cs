namespace DocEventsAttendanceCalendar.Domain.Interfaces
{
    public interface IAttendeeService
    {
        Task AddAttendeeToEvent(int eventId, int attendeeId);
        Task RemoveAttendeeFromEvent(int eventId, int attendeeId);
    }
}
