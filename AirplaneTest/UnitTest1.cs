using AndreAirLineMongoDbAirPlane.Service;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AirplaneTest
{
    public class UnitTest1
    {
        private List<AirPlaneDTO> _airplanes;

        private static AirPlaneService InitialDataBase()
        {
            var settings = new ConnectionMongoDb("AirPlaneTest", "DbAirPlaneTest", "mongodb://localhost:27017");
            AirPlaneService airPlaneService = new AirPlaneService(settings);
            return airPlaneService;
        }

        [Fact]
        public async Task Update()
        {
            var _airplane = InitialDataBase();
            var newAirplane = new AirPlaneDTO("HelloMyFriend", "Caribe", 200);
            await _airplane.Put(newAirplane);
            AirPlane airplane = await _airplane.Get("HelloMyFriend");
           

            Assert.Equal("Caribe", airplane.Name);
        }

        [Fact]
        public async Task Delete()
        {
            var _airplane = InitialDataBase();
            await _airplane.Delete("HelloMyFriend");
            AirPlane airplane = await _airplane.Get("HelloMyFriend");
            Assert.Null(airplane);
        }

        [Fact]
        public async Task Post()
        {
            var _airplane = InitialDataBase();
            var airplane = new AirPlaneDTO("HelloMyFriend", "Havai", 200); 
            var result = await _airplane.Post(airplane);

            Assert.Equal(200 ,result);
        }
        [Fact]
        public async Task Get()
        {
            var _airplane = InitialDataBase();
            AirPlane airplane = await _airplane.Get("HelloMyFriend");
            Assert.NotNull(airplane);
            
        }


        [Fact]
        public async Task GetAll()
        {
            var _airplane = InitialDataBase();
            IEnumerable<AirPlane> airplane = await _airplane.Get();
            Assert.Equal(3 , airplane.Count());
           
        }
    }
}
