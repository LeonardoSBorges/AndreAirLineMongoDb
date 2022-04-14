using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ModelShare
{
    public class Log
    {
        public Log(User user, object beforeEntity, object afterEntity, string operation, DateTime date)
        {
            User = user;
            BeforeEntity = beforeEntity;
            AfterEntity = afterEntity;
            Operation = operation;
            Date = date;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public object BeforeEntity { get; set; }
        public object AfterEntity { get; set; }
        public string  Operation { get; set; }
        public DateTime Date { get; set; }


    }
}
