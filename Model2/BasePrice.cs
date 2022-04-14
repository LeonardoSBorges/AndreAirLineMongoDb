﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare
{
    public class BasePrice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OriginId { get; set; }

        public string DestinyId { get; set; }

        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; }


        public BasePrice()
        {
               
        }

        public BasePrice(string originId, string destinyId, decimal price, DateTime dateAdded)
        {
            OriginId = originId;
            DestinyId = destinyId;
            Price = price;
            DateAdded = dateAdded;
        }

        public override string ToString()
        {
            return $"{OriginId},{DestinyId},{Price},{DateAdded}";
        }
    }
}
