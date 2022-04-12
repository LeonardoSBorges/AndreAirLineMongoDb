using ModelShare.DTO;
using ModelShare.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;

namespace Models2
{
    public class Airport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }
    
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

        public override string ToString()
        {
            return $"Id: {Id}\nIata: {Iata}\nName: {Name}\nAddress: {Address}";
        }
    }
}
