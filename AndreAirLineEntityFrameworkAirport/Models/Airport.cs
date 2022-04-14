
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Models
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

        public override string ToString()
        {
            return $"{Iata},{Name},{Continent},{Country}";
        }

    }
}
