using System;

namespace Calendar.Api.Exceptions
{
    public class CalendarEventNotFound : Exception
    {
        public CalendarEventNotFound(int eventId) : base($"CalendarEvent with id:{eventId} does not exit.")
        { }
    }
}