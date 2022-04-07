using AndreAirLineMongoDbFlight.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
            _valuesService.Post(flyDTO);
        }
        //[HttpPut]
        //[HttpDelete("{id}")]

    }
}
