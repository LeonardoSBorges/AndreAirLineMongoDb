using Models.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Fly
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Ticket { get; set; }
        public AirPort Origin { get; set; }
        public AirPort Destiny { get; set; }
        public AirPlane AirPlane { get; set; }
        public DateTime BoardingTime { get; set; }
        public DateTime DisembarkationTime { get; set; }

        public Fly()
        {

        }

        public Fly(string ticket, AirPort origin, AirPort destiny, AirPlane airPlane, DateTime boardingTime, DateTime disembarkationTime)
        {
            Ticket = ticket;
            Origin = origin;
            Destiny = destiny;
            AirPlane = airPlane;
            BoardingTime = boardingTime;
            DisembarkationTime = disembarkationTime;
        }


        public static async Task<Fly> ReturnFlyWithAllValues(Fly flight)
        {
            AirPort queryOringin = null, queryDestiny = null;
            AirPlane queryAirplane = null;
            queryOringin = await QueriesAndreAirLines.SearchAiport(flight.Origin.Iata);
            queryDestiny = await QueriesAndreAirLines.SearchAiport(flight.Destiny.Iata);
            queryAirplane = await QueriesAndreAirLines.SearchAirplane(flight.AirPlane.Enrollment);
            var newFlight = new Fly(flight.Ticket, queryOringin, queryDestiny, queryAirplane, flight.BoardingTime, flight.DisembarkationTime);
            newFlight.Id = flight.Id;
            return newFlight;
        }
    }
}
