using ModelShare.DTO;
using ModelShare.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;

namespace ModelShare
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string  Reserve { get; set; }
        public Fly Flight { get; set; }
        public Person Person { get; set; }
        public BasePrice BasePrice { get; set; }
        public Class Class { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Sale { get; set; }

        public Ticket()
        {

        }

        public Ticket(Fly flight, Person person, BasePrice basePrice, Class _class, DateTime registerDate, decimal totalValue, decimal sale)
        {
            Flight = flight;
            Person = person;
            BasePrice = basePrice;
            Class = _class;
            RegisterDate = registerDate;
            TotalValue = totalValue;
            Sale = sale;
        }

        public static async Task<Ticket> NewTicket(TicketDTO ticketDTO)
        {
            var fly = await QueriesAndreAirLines.SearchFly(ticketDTO.FlightId);
            var person = await QueriesAndreAirLines.SearchPerson(ticketDTO.PersonId);
            var basePrice = await QueriesAndreAirLines.SearchBasePrice(ticketDTO.BasePriceId);
            var _class = await QueriesAndreAirLines.SearchClass(ticketDTO.ClassId);

            ticketDTO.TotalValue += basePrice.Price + (basePrice.Price * (_class.Value / 100));

            var ticket = new Ticket(fly, person, basePrice, _class, ticketDTO.RegisterDate, ticketDTO.TotalValue, ticketDTO.Sale);
            return ticket;
        }
    }
}
