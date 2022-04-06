

using Models;
using Models.DTO;
using Models.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPort.Service
{
    public class AirPortService
    {
        private readonly IMongoCollection<AirPort> _airPort;
        public AirPortService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _airPort = database.GetCollection<AirPort>(settings.CollectionName);
        }

        public async Task<List<AirPort>> Get()
        {
            return await _airPort.Find(airport => true).ToListAsync();
        }

        public async Task<AirPort> Get(string Iata)
        {
            return await _airPort.Find(airport => airport.Iata == Iata).FirstOrDefaultAsync();
        }

        public async Task<AirPort> Post(AirPortDTO airPortDTO)
        {
            var searchAirPort = await _airPort.Find(airport => airport.Iata == airPortDTO.Iata).FirstOrDefaultAsync();
            var airPort = NewAirPort(airPortDTO);
            if (searchAirPort == null)
                _airPort.InsertOne(airPort);

            return airPort;
        }

        public async Task<AirPort> Put(string id, AirPortDTO airPortDTO)
        {
            var updateAirPort = _airPort.ReplaceOne(airport => airport.Id == id, NewAirPort(airPortDTO));
            return await _airPort.Find(airport => airport.Id == id).FirstOrDefaultAsync();
        }

        public void Delete(string Id)
        {
            _airPort.DeleteOne(Id);
        }

        public AirPort NewAirPort(AirPortDTO airPortDTO)
        {
            var airPort = new AirPort(airPortDTO.Iata, airPortDTO.Name, airPortDTO.Address);
            return  airPort;
        }
    }
}
