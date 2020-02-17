using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Api.Entities
{
    public class CalendarEvent
    {
        private CalendarEvent() { }

        public CalendarEvent(
            string name,
            long time,
            string location,
            string members,
            string eventOrganizer)
        {
            Name = name;
            Time = time;
            Location = location;
            Members = members;
            EventOrganizer = eventOrganizer;
        }

        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public long Time { get; private set; }
        public string Location { get; private set; }
        public string Members { get; private set; }
        public string EventOrganizer { get; private set; }
    }
}