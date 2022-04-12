using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public User User { get; set; }
        public object BeforeEntity { get; set; }
        public object AfterEntity { get; set; }
        public string  Operation { get; set; }
        public DateTime Date { get; set; }
    }
}
