using AndreAirLineMongoDbFlight.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbFlight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightService _valuesService;

        public FlightController(FlightService valuesService)
        {
            _valuesService = valuesService;
        }

        [HttpGet]
        public async Task<List<Fly>> Get() {
            return await _valuesService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Fly> Get(string ticket) {

            return await _valuesService.Get(ticket);
        }

        [HttpPost]
        public async Task<Fly> Post(FlyDTO flyDTO)
        {
           var resultInsertion = await _valuesService.Post(flyDTO);

            return resultInsertion;
        }

        [HttpPut]
        public async Task<Fly> Put(string id, FlyDTO flyDTO)
        {
            var result = await _valuesService.Update(id, flyDTO);

            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _valuesService.Delete(id);
            return NoContent();
        }
    }
}
