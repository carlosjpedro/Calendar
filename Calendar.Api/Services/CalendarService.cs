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
        Task<IEnumerable<CalendarEventDto>> GetEvents(string organizer);
        Task AddEvent(CalendarEvent eventDto);
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


        public Task<IEnumerable<CalendarEventDto>> GetEvents(string organizer) =>
            new Fixture().CreateManyAsync<CalendarEventDto>(20);

    }

    public static class AutoFixtureExtensions
    {
        public static Task<IEnumerable<T>> CreateManyAsync<T>(this Fixture fixture, int count) =>
            Task.FromResult(fixture.CreateMany<T>(count));
    }
}
