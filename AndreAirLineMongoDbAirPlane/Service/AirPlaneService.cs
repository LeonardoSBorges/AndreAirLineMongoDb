using Models;
using Models.DTO;
using Models.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPlane.Service
{
    public class AirPlaneService
    {
        private readonly IMongoCollection<AirPlane> _airPlane;

        public AirPlaneService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _airPlane = database.GetCollection<AirPlane>(settings.CollectionName);
        }

        public async Task<List<AirPlane>> Get()
        {
            return await _airPlane.Find(searchPerson => true).ToListAsync();
        }

        public async Task<AirPlane> Get(string enrollment)
        {
            return await _airPlane.Find(airplane => airplane.Enrollment == enrollment).FirstOrDefaultAsync();
        }

        public async Task<AirPlane> Post(AirPlaneDTO airPlaneDTO)
        {
            var searchAirPlane = await _airPlane.Find(airplane => airplane.Enrollment == airPlaneDTO.Enrollment).FirstOrDefaultAsync();
            var airPlane = AirPlane(airPlaneDTO);
            if (searchAirPlane == null)
            {
                _airPlane.InsertOne(airPlane);
            }

            return airPlane;
        }

        private AirPlane AirPlane(AirPlaneDTO airPlaneDTO)
        {
            AirPlane airPlane =  new AirPlane(airPlaneDTO.Enrollment, airPlaneDTO.Name, airPlaneDTO.Capacity) ;
            return airPlane;
        }

        public void Put(string enrollment, AirPlaneDTO airPlane)
        {
            _airPlane.ReplaceOne(airplane => airplane.Enrollment == enrollment, AirPlane(airPlane));
        }
        public void Delete(string enrollment)
        {
             _airPlane.DeleteOneAsync(airPlane => airPlane.Enrollment == enrollment);
        }
    }
}
