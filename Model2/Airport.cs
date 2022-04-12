using ModelShare.DTO;
using ModelShare.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ModelShare
{
    public class Airport
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("iata")]
        public string Iata { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }

        public Airport()
        {

        }

        public Airport(string iata, string name, Address address)
        {
            Iata = iata;
            Name = name;
            Address = address;
        }


        public static async Task<Airport> NewAirPort(AirPortDTO airPortDTO)
        {
            Address address = await QueriesAndreAirLines.HttpCorreios(airPortDTO.Address.Cep);
            address.Number = airPortDTO.Address.Number;
            var airPort = new Airport(airPortDTO.Iata, airPortDTO.Name, address);
            return airPort;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nIata: {Iata}\nName: {Name}\nAddress: {Address}";
        }
    }
}
