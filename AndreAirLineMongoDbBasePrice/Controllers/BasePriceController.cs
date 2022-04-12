using AndreAirLineMongoDbBasePrice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbBasePrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasePriceController : ControllerBase
    {
        private readonly BasePriceService _basePriceController;

        public BasePriceController(BasePriceService basePriceController)
        {
            _basePriceController = basePriceController;
        }

        [HttpGet]
        public async Task<List<BasePrice>> Get()
        {
            var result = await _basePriceController.Get();
            return result;
        }

        [HttpGet("{id}", Name = "GetBasePrice")]
        public async Task<BasePrice> Get(string id)
        {
            var result = await _basePriceController.Get(id);
            return result;
        }

        [HttpPost]
        public async Task<BasePrice> Post(BasePriceDTO basePriceDTO)
        {
            return await _basePriceController.Post(basePriceDTO);
        }

        [HttpPut]
        public IActionResult Update(BasePrice basePrice)
        {
            var result = _basePriceController.Update(basePrice);
            if (result.StatusCode <= 299)
                return Ok(result);
            else if (result.StatusCode <= 499)
                return NotFound(result);
            else
                return BadRequest();
           
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _basePriceController.Delete(id);
            if (result.StatusCode <= 299)
                return Ok(result);
            else if (result.StatusCode <= 499)
                return NotFound(result);
            else
                return BadRequest();
        }
    }
}
