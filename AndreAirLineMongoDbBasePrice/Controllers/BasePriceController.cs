using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbBasePrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasePriceController : ControllerBase
    {
        private readonly BasePriceController _basePriceController;

        public BasePriceController(BasePriceController basePriceController)
        {
            _basePriceController = basePriceController;
        }

        [HttpGet]
        public async Task<List<BasePrice>> Get()
        {
            return await _basePriceController.Get();
        }

        [HttpGet("{id}")]
        public async Task<List<BasePrice>> Get(string id)
        {
            return await _basePriceController.Get(id);
        }
        [HttpPost]
        public async Task<BasePrice> Post(BasePriceDTO basePriceDTO)
        {
            return await _basePriceController.Post(basePriceDTO);
        }
        [HttpPut]
        public IActionResult Update(string id, BasePriceDTO basePriceDTO)
        {
            _basePriceController.Update(id, basePriceDTO);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _basePriceController.Delete(id);
            return NoContent();
        }
    }
}
