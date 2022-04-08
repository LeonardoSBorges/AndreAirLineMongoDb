using AndreAirLineMongoDbBasePrice.Services;
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
        //[HttpPut]
        //public IActionResult Update(string id, BasePriceDTO basePriceDTO)
        //{
        //    _basePriceController.Update(id, basePriceDTO);
        //    return NoContent();
        //}
        //[HttpDelete]
        //public IActionResult Delete(string id)
        //{
        //    _basePriceController.Delete(id);
        //    return NoContent();
        //}
    }
}
