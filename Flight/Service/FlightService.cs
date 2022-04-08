using MongoDB.Driver;
using Models;
using Models.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTO;
using Models.Services;
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
            return await _flight.Find(flight => true).ToListAsync();
        }

        public async Task<Fly> Get(string ticket)
        {
            return await _flight.Find(flight => flight.Ticket == ticket).FirstOrDefaultAsync();
        }

        public async Task<Fly> Post(FlyDTO flyDTO)
        {
            var fly = await NewFly(flyDTO);
            _flight.InsertOne(fly);
            return await _flight.Find(searchFly => searchFly == fly).FirstOrDefaultAsync();
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
        public async Task<Fly> NewFly(FlyDTO flyDTO, Fly updateFly = null)
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
