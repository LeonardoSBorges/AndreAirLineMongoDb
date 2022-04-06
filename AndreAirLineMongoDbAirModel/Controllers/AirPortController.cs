using System.Collections.Generic;
using System.Threading.Tasks;
using AndreAirLineMongoDbAirPort.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;

namespace AndreAirLineMongoDbAirModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPortController : ControllerBase
    {
        private readonly AirPortService _airModelController;

        public AirPortController(AirPortService airModelController)
        {
            _airModelController = airModelController;
        }

        [HttpGet]
        public async Task<List<AirPort>> Get()
        {
            return await _airModelController.Get();
        }

        [HttpGet("{id}", Name = "GetAirPort")]
        public async Task<AirPort> Get(string ticket)
        {
            return await _airModelController.Get(ticket);
        }

        [HttpPost]
        public async Task<AirPort> Post(AirPortDTO airport)
        {
            return await _airModelController.Post(airport);
        }

        [HttpPut]
        public async Task<AirPort> Put(string id, AirPortDTO airPort)
        {
            return await _airModelController.Put(id, airPort);
            
        }

        [HttpDelete]
        public IActionResult Delete(string ticket)
        {
            _airModelController.Delete(ticket);
            return NoContent();
        }

    }
}
