using AndreAirLineMongoDbAirPlane.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
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

        [HttpGet("{iata}")]
        public async Task<AirPlane> Get(string iata)
        {
            var airplane = await _airPlane.Get(iata);
           return airplane;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AirPlaneDTO airPlane)
        {
            var result = await _airPlane.Post(airPlane);
            if (result == 400)
                return BadRequest();
            return Ok();
             
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
