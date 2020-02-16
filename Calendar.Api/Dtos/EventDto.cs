using Calendar.Api.Serializers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Api.Dtos
{
    public class EventDto
    {
        public int? Id { get; set; }

        [Required]
        public long? Time { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Location { get; set; }
        
        [JsonConverter(typeof(CsvConverter))]
        [RegularExpression("^[Aa-Zz]+(,[Aa-Zz]+)*$")]
        public string Members { get; set; }

        [Required(AllowEmptyStrings = false)]        
        public string EventOrganizer { get; set; }
    }
}
