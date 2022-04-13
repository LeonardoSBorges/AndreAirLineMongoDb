using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AndreAirLines.EF.Models
{
    public class Airport
    {
        [Key]
        public string Iata { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("continent")]
        public string Continent { get; set; }
       
        [JsonProperty("country")]
        public string Country { get; set; }

    }
}
