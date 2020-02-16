using AutoFixture;
using Calendar.Api.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Api.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<EventDto>> GetEvents(string organizer);
    }

    public class CalendarService : ICalendarService
    {
        public Task<IEnumerable<EventDto>> GetEvents(string organizer) =>
            new Fixture().CreateManyAsync<EventDto>(20);

    }

    public static class AutoFixtureExtensions
    {
        public static Task<IEnumerable<T>> CreateManyAsync<T>(this Fixture fixture, int count) =>
            Task.FromResult(fixture.CreateMany<T>(count));
    }
}
