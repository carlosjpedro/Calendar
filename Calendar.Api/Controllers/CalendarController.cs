using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Calendar.Api.Dtos;
using Calendar.Api.Entities;
using Calendar.Api.Services;
using Microsoft.AspNetCore.Mvc;

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
        public Task<IEnumerable<CalendarEventDto>> Get(string organizer) 
        {
            return _calendarService.GetEvents(organizer);
        }

        [HttpGet]
        public Task<IEnumerable<CalendarEventDto>> GetEventsByLocation(string location)
        {
            return _calendarService.GetEventsByLocation(location);
        }

        [HttpPost]
        public Task Post(CalendarEventDto eventDto)
        {
            var calendarEvent = _mapper.Map<CalendarEvent>(eventDto);
            return _calendarService.AddEvent(calendarEvent);
        }
        
        [HttpPut]
        public async Task UpdateEvent([Required]int? eventId, CalendarEventDto eventDto)
        {
            var calendarEvent = _mapper.Map<CalendarEvent>(eventDto);
            await _calendarService.UpdateEvent(eventId.Value, calendarEvent);
        }

        [HttpDelete]
        public  Task DeleteEvent(int eventId)
        {
            return _calendarService.DeleteEvent(eventId);
        }
    }
}
