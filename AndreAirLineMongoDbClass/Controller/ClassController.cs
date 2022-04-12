using AndreAirLineMongoDbClass.Services;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
using ModelShare.Services;
using ModelShare.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbClass.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassServices _classService;
        public ClassController(ClassServices classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<List<Class>> GetAll()
        {
            return await _classService.GetAll();
        }

        [HttpGet("{id}", Name = "GetName")]
        public async Task<Class> Get(string id)
        {
            return await _classService.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClassDTO newClassDTO)
        {
            var result = await _classService.Post(newClassDTO);
            if(result.StatusCode >= 400)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Class newClass)
        {
            var result = await _classService.Update(newClass);

            if (result.StatusCode <= 299)
                return Ok(result);
            return NotFound(result);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _classService.Delete(id);
            if (result.StatusCode < 299)
                return Ok(result);
            else 
                return NotFound(result);
        }
    }
}
