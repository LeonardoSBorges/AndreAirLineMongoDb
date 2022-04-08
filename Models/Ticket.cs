using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string  Reserve { get; set; }
        //public Fly Flight { get; set; }
        //public Person Person { get; set; }
        //public BasePrice BasePrice { get; set; }
        //public Class Class { get; set; }
        //public DateTime RegisterDate { get; set; }
        //public decimal TotalValue { get; set; }
        //public decimal Sale { get; set; }

        //public Ticket()
        //{

        //}

        //public Ticket(Fly flight, Person person, BasePrice basePrice, Class _class, DateTime registerDate, decimal totalValue, decimal sale)
        //{
        //    Flight = flight;
        //    Person = person;
        //    BasePrice = basePrice;
        //    Class = _class;
        //    RegisterDate = registerDate;
        //    TotalValue = totalValue;
        //    Sale = sale;
        //}
    }
}
