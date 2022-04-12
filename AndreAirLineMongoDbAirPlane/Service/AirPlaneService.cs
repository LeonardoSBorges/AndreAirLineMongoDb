using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;
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
            AirPlane airPlane = null;
            try
            {
                var searchAirPlane = await _airPlane.Find(airplane => airplane.Enrollment == airPlaneDTO.Enrollment).FirstOrDefaultAsync();
                if (searchAirPlane == null)
                    _airPlane.InsertOne(new AirPlane(airPlaneDTO.Enrollment, airPlaneDTO.Name, airPlaneDTO.Capacity));
            }
            catch
            {
                throw;
            }
            return airPlane;
        }
        public async Task Put(AirPlaneDTO airPlaneDTO)
        {
            try
            {
                var airplaneExists = await _airPlane.Find(airplane => airplane.Enrollment == airPlaneDTO.Enrollment).FirstOrDefaultAsync();
                if (airplaneExists != null)
                {
                    var airplane = new AirPlane(airPlaneDTO.Enrollment, airPlaneDTO.Name, airPlaneDTO.Capacity);

                    _airPlane.ReplaceOne(airplane => airplane.Enrollment == airPlaneDTO.Enrollment, airplane);
                }
                else
                {
                    //throw;
                }
            }
            catch
            {
                throw;
            }
        }
        public void Delete(string enrollment)
        {
            _airPlane.DeleteOneAsync(airPlane => airPlane.Enrollment == enrollment);
        }
    }
}
