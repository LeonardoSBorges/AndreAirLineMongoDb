using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Services;
using ModelShare.Util;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPlane.Service
{
    public class AirPlaneService : IAirplaneService
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

        public async Task<dynamic> Post(AirPlaneDTO airPlaneDTO)
        {
            AirPlane airPlane = null;
            try
            {
                var searchAirPlane = await _airPlane.Find(airplane => airplane.Enrollment == airPlaneDTO.Enrollment).FirstOrDefaultAsync();
                if (searchAirPlane == null)
                {
                    _airPlane.InsertOne(new AirPlane(airPlaneDTO.Enrollment, airPlaneDTO.Name, airPlaneDTO.Capacity));
                    return 200;
                }
            }
            catch
            {
                throw;
            }
            return 400;
        }
        public async Task Put(AirPlaneDTO airPlaneDTO)
        {
            try
            {
                var airplaneExists = await _airPlane.Find(airplane => airplane.Enrollment == airPlaneDTO.Enrollment).FirstOrDefaultAsync();
                if (airplaneExists != null)
                {
                    var airPlane = new AirPlane(airPlaneDTO.Enrollment, airPlaneDTO.Name, airPlaneDTO.Capacity);

                    await PostAndreAirLines.PostLog(new LogDTO(null, airplaneExists.ToString(), airPlane.ToString(), "Update", DateTime.Now));
                    _airPlane.ReplaceOne(airplane => airplane.Enrollment == airPlaneDTO.Enrollment, airPlane);
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
        public async Task Delete(string enrollment)
        {
            await _airPlane.DeleteOneAsync(airPlane => airPlane.Enrollment == enrollment);

            await PostAndreAirLines.PostLog(new LogDTO(null, enrollment, "delete", "Update", DateTime.Now));
        }
    }
}
