using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

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
    }
}
