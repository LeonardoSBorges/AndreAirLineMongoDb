using System.Collections.Generic;
using System.Threading.Tasks;
using AndreAirLineMongoDbAirPort.Service;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;

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
        public async Task<List<Airport>> Get()
        {
            return await _airModelController.Get();
        }

        [HttpGet("{iata}", Name = "GetAirPort")]
        public async Task<Airport> Get(string iata)
        {
            return await _airModelController.Get(iata);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AirPortDTO airport)
        {
            var result = await _airModelController.Post(airport);
            if (result == null)
            {
                return NotFound(new ApiResponse(400, $"Nao foi possivel inserir o aeroporto no banco de dados, por favor verifique se todos os campos estao preenchidos!"));
            }
            
            return Ok(CreatedAtRoute("GetAirPort", new { iata = airport.Iata }, airport));
        }

        [HttpPut]
        public async Task<ActionResult> Put(AirPortDTO airPort)
        {
            var airport = await _airModelController.Put(airPort);
            if (airport >= 400)
            {
                return NotFound(new ApiResponse(airport));
            }
            return Ok(new ApiResponse(airport, $"Sucesso na atualizacao!"));
        }

        [HttpDelete("{iata}")]
        public IActionResult Delete(string iata)
        {
            _airModelController.Delete(iata);
            return NoContent();
        }

    }
}
