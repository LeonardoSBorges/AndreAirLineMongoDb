using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ModelShare
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }

        public Person(string document, string name, string phoneNumber, DateTime date, string email, Address address)
        {
            Document = document;
            Name = name;
            PhoneNumber = phoneNumber;
            Date = date;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Document},{Name},{PhoneNumber}, {Date}, {Email}, {Address.ToString()}";
        }
    }
}
