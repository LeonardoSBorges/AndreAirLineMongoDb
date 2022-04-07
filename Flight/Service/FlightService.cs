using MongoDB.Driver;
using Models;
using Models.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTO;
using Models.Services;

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
            var fly = NewFly(flyDTO);
            _flight.InsertOne(fly);
            return await _flight.Find(searchFly => searchFly == fly).FirstOrDefaultAsync(); ;
        }

        public async Task<Fly> NewFly(FlyDTO flyDTO)
        {
            var Origin =  QueriesAndreAirLines.SearchAiportInApi(flyDTO.Origin);
            var Destiny = QueriesAndreAirLines.SearchAiportInApi(flyDTO.Destiny);

            var resultFly = await new Fly(flyDTO.Ticket, Origin, Destiny, flyDTO.BoardingTime, flyDTO.DisembarkationTime);
            return ;
        }

        public bool Post(string ticket, Fly fly)
        {
            _flight.ReplaceOne(searchFly => searchFly.Ticket == ticket, fly);
            return true;
        }
    }
}
