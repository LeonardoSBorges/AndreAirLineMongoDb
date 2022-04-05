using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AirPlane
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Enrollment { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
