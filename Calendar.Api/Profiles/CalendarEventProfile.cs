
using AutoMapper;
using Calendar.Api.Dtos;
using Calendar.Api.Entities;

namespace Calendar.Api.Profiles
{
    public class CalendarEventProfile : Profile
    {
        public CalendarEventProfile()
        {
            CreateMap<CalendarEventDto, CalendarEvent>()
            .ConstructUsing(x => new CalendarEvent(x.Name, x.Time.Value, x.Location, x.Members, x.EventOrganizer))
            .ReverseMap();

        }
    }
}