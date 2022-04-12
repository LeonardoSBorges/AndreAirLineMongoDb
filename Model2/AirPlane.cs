using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare
{
    public class AirPlane
    {
        public AirPlane()
        {

        }
        public AirPlane(string enrollment, string name, int capacity)
        {
            Enrollment = enrollment;
            Name = name;
            Capacity = capacity;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Enrollment { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
