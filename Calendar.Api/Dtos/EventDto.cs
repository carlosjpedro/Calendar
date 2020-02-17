using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Api.Dtos
{
    public class CalendarEventDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public long? Time { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Location { get; set; }

        [RegularExpression("^[aA-zZ]+(,[aA-zZ]+)*$")]
        public string Members { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string EventOrganizer { get; set; }
    }
}
