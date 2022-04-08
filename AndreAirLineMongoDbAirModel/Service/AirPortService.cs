

using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Models.Services;
using Models.Util;
using MongoDB.Driver;
using System;
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

        public async Task<AirPort> Get(string iata)
        {
            return await _airPort.Find(airport => airport.Iata == iata).FirstOrDefaultAsync();
        }

        public async Task<AirPort> Post(AirPortDTO airPortDTO)
        {
            try
            {
                AirPort airPort = null;
                if (AirPortDTO.VerifyExistsData(airPortDTO))
                {
                    var searchAirPort = await _airPort.Find(airport => airport.Iata == airPortDTO.Iata).FirstOrDefaultAsync();

                    airPort = await AirPort.NewAirPort(airPortDTO);
                    if (searchAirPort == null)
                        _airPort.InsertOne(airPort);
                    return airPort;
                }
                else
                    return null;
            }
            catch(Exception)
            {
                
            }

            return null;
        }

        public async Task<int> Put(AirPortDTO airPortDTO)
        {
            try
            {
                var searchAirport = _airPort.Find(airport => airport.Iata == airPortDTO.Iata).FirstOrDefault();
                if (searchAirport == null)
                    return 404;
                var newValue = await AirPort.NewAirPort(airPortDTO);
                newValue.Id = searchAirport.Id;
                _airPort.ReplaceOne(airport => airport.Iata == airPortDTO.Iata, newValue);
                return 204;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string Iata)
        {
            _airPort.DeleteOne(airPort => airPort.Iata == Iata);
        }

        public async Task<AirPort> NewAirPort(AirPortDTO airPortDTO)
        {
            Address address = await QueriesAndreAirLines.HttpCorreios(airPortDTO.Address.Cep);
            address.Number = airPortDTO.Address.Number;
            var airPort = new AirPort(airPortDTO.Iata, airPortDTO.Name, address);
            return airPort;
        }
    }
}
