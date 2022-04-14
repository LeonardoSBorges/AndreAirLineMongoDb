

using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Services;
using ModelShare.Util;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPort.Service
{
    public class AirPortService
    {
        private readonly IMongoCollection<Airport> _airPort;
        public AirPortService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _airPort = database.GetCollection<Airport>(settings.CollectionName);
        }

        public async Task<List<Airport>> Get()
        {
            return await _airPort.Find(airport => true).ToListAsync(); ;
        }

        public async Task<Airport> Get(string iata)
        {
            return await _airPort.Find(airport => airport.Iata == iata).FirstOrDefaultAsync();
        }

        public async Task<Airport> Post(AirPortDTO airPortDTO)
        {
            try
            {
                Airport airPort = null;
                if (AirPortDTO.VerifyExistsData(airPortDTO))
                {
                    var searchAirPort = await _airPort.Find(airport => airport.Iata == airPortDTO.Iata).FirstOrDefaultAsync();

                    if (searchAirPort != null)
                        return null;

                    airPort = await Airport.NewAirPort(airPortDTO);

                    await PostAndreAirLines.PostLog(new LogDTO(null, null, airPort.ToString(), "Create", DateTime.Now));
                    _airPort.InsertOne(airPort);
                    return airPort;
                }
                else
                    return null;
            }
            catch (Exception)
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
                var newValue = await Airport.NewAirPort(airPortDTO);
                newValue.Id = searchAirport.Id;

                await PostAndreAirLines.PostLog(new LogDTO(null, searchAirport.ToString(), newValue.ToString(), "Create", DateTime.Now));
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

        public async Task<Airport> NewAirPort(AirPortDTO airPortDTO)
        {
            Address address = await QueriesAndreAirLines.HttpCorreios(airPortDTO.Address.Cep);
            address.Number = airPortDTO.Address.Number;
            var airPort = new Airport(airPortDTO.Iata, airPortDTO.Name, address);
            return airPort;
        }
    }
}
