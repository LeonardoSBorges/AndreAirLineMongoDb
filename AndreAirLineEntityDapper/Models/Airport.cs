using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLineDapper.Models
{
    public class Airport
    {
        public readonly static string INSERT = "INSERT INTO Airport(iata, name, address) VALUES(@iata, @name, @address)";
        public readonly static string GETALL = "SELECT iata, name, address FROM dbo.Airport";
        [Key]
        public string Iata { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
