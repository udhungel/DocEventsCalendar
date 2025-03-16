using DocEventsCalendar.Domain.Interfaces;
using DocEventsCalendar.Domain.Entities;
using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.DTOs;

namespace DocEventsCalendar.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ResponseEventDto> CreateEvent(RequestEventDto requestEventDto)
        {
            var eventEntity = new Event
            {
                Title = requestEventDto.Title,
                Description = requestEventDto.Description,
                StartTime = requestEventDto.StartTime,
                EndTime = requestEventDto.EndTime
            };
            var createdEvent = await _eventRepository.CreateEvent(eventEntity);
            return new ResponseEventDto
            {
                Id = createdEvent.Id,
                Title = createdEvent.Title,
                Description = createdEvent.Description,
                StartTime = createdEvent.StartTime,
                EndTime = createdEvent.EndTime
            };
        }
        public async Task<ResponseEventDto> UpdateEvent(Event updateEntity)
        {           
            var updatedEvent =  await _eventRepository.UpdateEvent(updateEntity);
            return new ResponseEventDto
            {
                Id = updatedEvent.Id,
                Title = updatedEvent.Title,
                Description = updatedEvent.Description,
                StartTime = updatedEvent.StartTime,
                EndTime = updatedEvent.EndTime
            };
        }
        public async Task<bool> DeleteEvent(int id)
        {
         return  await _eventRepository.DeleteEvent(id);
           
        }
        public async Task<List<ResponseEventDto>> GetAllEvents()
        {
            var events = await _eventRepository.GetAllEvents();
            var responseEvents = new List<ResponseEventDto>();
            foreach (var eventEntity in events)
            {
                responseEvents.Add(new ResponseEventDto
                {
                    Id = eventEntity.Id,
                    Title = eventEntity.Title,
                    Description = eventEntity.Description,
                    StartTime = eventEntity.StartTime,
                    EndTime = eventEntity.EndTime
                });
            }
            return responseEvents;
        }
        public async Task<ResponseEventDto> GetEventById(int id)
        {
            var eventEntity = await _eventRepository.GetEventById(id);
            if (eventEntity == null) 
                return null;
            return new ResponseEventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime
            };
        }
    }
}
