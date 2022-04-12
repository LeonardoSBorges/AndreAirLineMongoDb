using AndreAirLineMongoDbFlight.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;
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

        [HttpGet("{ticket}")]
        public async Task<Fly> Get(string ticket) {

            return await _valuesService.Get(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> Post(FlyDTO flyDTO)
        {
            var resultInsertion = await _valuesService.Post(flyDTO);
            if (resultInsertion >= 400) 
            {
                return NotFound(new ApiResponse(resultInsertion, "Ocorreu um erro ao criar a solicitacao de voo, verifique se os campos estao preenchidos corretamente!"));
            }
            return Ok(new ApiResponse(resultInsertion, "Voo inserido com sucesso!"));
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
