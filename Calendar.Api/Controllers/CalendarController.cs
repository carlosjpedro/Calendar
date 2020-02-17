using AutoMapper;
using Calendar.Api.Dtos;
using Calendar.Api.Entities;
using Calendar.Api.Exceptions;
using Calendar.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Calendar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        private readonly IMapper _mapper;

        public CalendarController(ICalendarService calendarService, IMapper mapper)
        {
            _calendarService = calendarService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("query")]
        public async Task<IEnumerable<CalendarEventDto>> Get(string organizer, string location, string name, int? eventId)
        {
            if (string.IsNullOrWhiteSpace(organizer) && string.IsNullOrWhiteSpace(location)
            && string.IsNullOrWhiteSpace(name) && !eventId.HasValue)
            {
                throw new InvalidRequest();
            }

            IEnumerable<CalendarEvent> calendarEvents = await _calendarService.GetEvents(organizer, location, name, eventId);
            return _mapper.Map<IEnumerable<CalendarEventDto>>(calendarEvents);
        }

        [HttpPost]
        public Task Post(CalendarEventDto eventDto)
        {
            CalendarEvent calendarEvent = _mapper.Map<CalendarEvent>(eventDto);
            return _calendarService.AddEvent(calendarEvent);
        }

        [HttpPut]
        public Task UpdateEvent([Required]int? eventId, CalendarEventDto eventDto)
        {
            CalendarEvent calendarEvent = _mapper.Map<CalendarEvent>(eventDto);
            return _calendarService.UpdateEvent(eventId.Value, calendarEvent);
        }

        [HttpDelete]
        public Task DeleteEvent(int eventId)
        {
            return _calendarService.DeleteEvent(eventId);
        }
    }
}
