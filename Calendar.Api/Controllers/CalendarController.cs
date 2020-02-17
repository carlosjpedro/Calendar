using System;
using System.Collections.Generic;
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

        [HttpPost]
        public Task Post(CalendarEventDto eventDto)
        {
            var calendarEvent = _mapper.Map<CalendarEvent>(eventDto);
            return _calendarService.AddEvent(calendarEvent);
        }    
    }
}
