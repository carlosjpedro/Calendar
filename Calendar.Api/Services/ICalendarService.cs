using Calendar.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Api.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<CalendarEvent>> GetEvents(string organizer, string location, string name, int? eventId);
        Task AddEvent(CalendarEvent eventDto);
        Task UpdateEvent(int eventId, CalendarEvent calendarEvent);
        Task DeleteEvent(int eventId);
    }
}
