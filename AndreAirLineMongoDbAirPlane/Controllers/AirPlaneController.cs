using AndreAirLineMongoDbAirPlane.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPlane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPlaneController : ControllerBase
    {
        private readonly AirPlaneService _airPlane;
        public AirPlaneController(AirPlaneService airPlane)
        {
            _airPlane = airPlane;
        }

        [HttpGet]
        public async Task<List<AirPlane>> Get()
        {

            return await _airPlane.Get();
        }

        [HttpGet("{id}")]
        public async Task<AirPlane> Get(string enrollment)
        {
            var airplane = await _airPlane.Get(enrollment);
           return airplane;
        }

        [HttpPost]
        public async Task<AirPlane> Post(AirPlaneDTO airPlane)
        {
            return await _airPlane.Post(airPlane);
             
        }

        [HttpPut]
        public async Task<IActionResult> Put(AirPlaneDTO airPlane)
        {
            await _airPlane.Put(airPlane);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult  Delete(string enrollment)
        {
             _airPlane.Delete(enrollment);
            return NoContent();
        }
    }

}
