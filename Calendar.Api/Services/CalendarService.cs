using Calendar.Api.Entities;
using Calendar.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Api.Services
{

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
            return _eventRepository.DeleteEvent(eventId);
        }

        public Task<IEnumerable<CalendarEvent>> GetEvents(string organizer)
        {
            return _eventRepository.GetEventsByOrganizer(organizer);
        }

        public Task<IEnumerable<CalendarEvent>> GetEvents(string organizer, string location, string name, int? eventId)
        {
            return _eventRepository.FilterEvents(organizer, location, name, eventId);
        }

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
