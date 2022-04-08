using Models.DTO;
using Models.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;

namespace Models
{
    public class AirPort
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public AirPort()
        {

        }

        public AirPort(string iata, string name, Address address)
        {
            Iata = iata;
            Name = name;
            Address = address;
        }


        public static async Task<AirPort> NewAirPort(AirPortDTO airPortDTO)
        {
            Address address = await QueriesAndreAirLines.HttpCorreios(airPortDTO.Address.Cep);
            address.Number = airPortDTO.Address.Number;
            var airPort = new AirPort(airPortDTO.Iata, airPortDTO.Name, address);
            return airPort;
        }
    }
}
