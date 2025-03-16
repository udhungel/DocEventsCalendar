using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;
using DocEventsCalendar.Domain.Entities;
using DocEventsCalendar.Domain.Interfaces;
using DocEventsCalendar.Domain.Services;
using Moq;

namespace DocEventsAttendeeCalendar.TestProject
{
    public class EventServiceTests
    {
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        private readonly EventService _eventService;
        public EventServiceTests()
        {
            _eventRepositoryMock = new Mock<IEventRepository>();
            _eventService = new EventService(_eventRepositoryMock.Object);
        }
        [Fact]
        public async Task CreateEvent_Should_CreateNewEvent()
        {
            // Arrange
            var reqDto = new RequestEventDto { Title = "Test1", Description = "Test Description", StartTime = DateTime.Now, EndTime = DateTime.Now };
            var newEvent = new Event { Title = "Test1", Description = "Test Description" };
            // Act
            _eventRepositoryMock
            .Setup(repo => repo.CreateEvent(It.IsAny<Event>()))
            .ReturnsAsync(newEvent);

            var result = await _eventService.CreateEvent(reqDto);

            Assert.NotNull(result);
            Assert.Equal(newEvent.Title, result.Title);
            Assert.Equal(newEvent.Description, result.Description);
            Assert.Equal(newEvent.StartTime, result.StartTime);
            Assert.Equal(newEvent.EndTime, result.EndTime);
        }
    }
}