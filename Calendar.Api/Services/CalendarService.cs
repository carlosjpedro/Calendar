using AutoFixture;
using Calendar.Api.Dtos;
using Calendar.Api.Entities;
using Calendar.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Api.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<CalendarEvent>> GetEvents(string organizer);
        Task AddEvent(CalendarEvent eventDto);
        Task UpdateEvent(int eventId, CalendarEvent calendarEvent);
        Task<IEnumerable<CalendarEvent>> GetEventsByLocation(string location);
        Task DeleteEvent(int eventId);
    }

    public class CalendarService : ICalendarService
    {
        private readonly IEventRepository _eventRepository;

        public CalendarService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public Task AddEvent(CalendarEvent eventDto)
        {
            return _eventRepository.AddEvent(eventDto);
        }

        public Task DeleteEvent(int eventId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CalendarEvent>> GetEvents(string organizer) =>
             _eventRepository.GetEventsByOrganizer(organizer);
            

        public Task<IEnumerable<CalendarEvent>> GetEventsByLocation(string location)
        {
            return _eventRepository.GetEventsByLocation(location);
        }

        public Task UpdateEvent(int eventId, CalendarEvent calendarEvent)
        {
            return _eventRepository.UpdateEvent(eventId, calendarEvent);
        }
    }
}
