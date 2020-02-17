using System;

namespace Calendar.Api.Exceptions
{
    public class CalendarEventNotFound : Exception
    {
        public CalendarEventNotFound(int eventId) : base($"CalendarEvent with id:{eventId} does not exit.")
        { }
    }

    public class InvalidRequest : Exception
    {
        public InvalidRequest() : base("At least one filter is necessrary for query") { }
    }
}