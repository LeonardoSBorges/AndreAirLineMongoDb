using MongoDB.Driver;
using ModelShare;
using ModelShare.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelShare.DTO;
using ModelShare.Services;
using System;

namespace AndreAirLineMongoDbFlight.Service
{
    public class FlightService
    {
        private readonly IMongoCollection<Fly> _flight;

        public FlightService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _flight = database.GetCollection<Fly>(settings.CollectionName);
        }

        public async Task<List<Fly>> Get()
        {
            List<Fly> flights = new List<Fly>();
            var result = await _flight.Find(flight => true).ToListAsync();
            foreach (var flight in result) {
                var value = await Fly.ReturnFlyWithAllValues(flight);

                flights.Add(value);
            }
            return flights;
        }

        public async Task<Fly> Get(string ticket)
        {
            
            var flight = await _flight.Find(flight => flight.Ticket == ticket).FirstOrDefaultAsync();
            flight = await Fly.ReturnFlyWithAllValues(flight);
            return flight;
        }

        public async Task<int> Post(FlyDTO flyDTO)
        {
            try
            {
                var searchFlySearch = await _flight.Find(searchFly => searchFly.Ticket == flyDTO.Ticket).FirstOrDefaultAsync();
              
                if (searchFlySearch != null)
                    return 404;

                var fly = await NewFly(flyDTO);
                _flight.InsertOne(fly);
                return 200;
            }
            catch
            {

            }
            return 404;
        }

        public async Task<Fly> Update(string id, FlyDTO flyDTO)
        {
            Fly searchFly =  await _flight.Find(searchFly => searchFly.Id == id).FirstOrDefaultAsync();
            var fly = await NewFly(flyDTO);
            _flight.ReplaceOne(searchFly => searchFly.Id == id, fly);
            return fly;
        }

        public void Delete(string id)
        {
            _flight.DeleteOne(id);
        }
        public async Task<Fly> NewFly(FlyDTO flyDTO)
        {
            try
            {
                var Origin = await QueriesAndreAirLines.SearchAiport(flyDTO.Origin);
                var Destiny = await QueriesAndreAirLines.SearchAiport(flyDTO.Destiny);
                var Airplane = await QueriesAndreAirLines.SearchAirplane(flyDTO.AirPlane);
                var resultFly = new Fly(flyDTO.Ticket, Origin, Destiny, Airplane, flyDTO.BoardingTime, flyDTO.DisembarkationTime);
                
                return resultFly;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Post(string ticket, Fly fly)
        {
            _flight.ReplaceOne(searchFly => searchFly.Ticket == ticket, fly);
            return true;
        }
    }
}
