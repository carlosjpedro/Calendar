using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Api.Entities;
using Calendar.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Api.Repositories
{
    public interface IEventRepository
    {
        Task AddEvent(CalendarEvent calendarEvent);
        Task<IEnumerable<CalendarEvent>> GetEventsByOrganizer(string organizer);
        Task<IEnumerable<CalendarEvent>> GetEventsByLocation(string location);
        Task DeleteEvent(int eventId);
        Task<CalendarEvent> GetEventById(int eventId);
        Task UpdateEvent(int eventId, CalendarEvent calendarEvent);
    }

    public class EventRepository : IEventRepository
    {
        private EventDbContext _dbContext;
        public EventRepository(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEvent(CalendarEvent calendarEvent)
        {
            await _dbContext.CalendarEvents.AddAsync(calendarEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEvent(int eventId)
        {
            var calendarEvent = await GetEventById(eventId);
            _dbContext.CalendarEvents.Remove(calendarEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CalendarEvent> GetEventById(int eventId)
        {
            var calendarEvent = await _dbContext.CalendarEvents.FirstOrDefaultAsync(x => x.Id == eventId);
            if (calendarEvent == null)
            {
                throw new CalendarEventNotFound(eventId);
            }

            return calendarEvent;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventsByLocation(string location)
        {
            return await _dbContext.CalendarEvents.Where(x => x.Location == location).ToListAsync();
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventsByOrganizer(string organizer)
        {
            return await _dbContext.CalendarEvents.Where(x => x.EventOrganizer == organizer).ToListAsync();
        }

        public async Task UpdateEvent(int eventId, CalendarEvent calendarEvent)
        {
            var oldEvent = await GetEventById(eventId);
            _dbContext.CalendarEvents.Attach(calendarEvent);
            await _dbContext.SaveChangesAsync();
        }
    }

    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
    }
}