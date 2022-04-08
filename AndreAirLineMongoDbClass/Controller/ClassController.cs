using AndreAirLineMongoDbClass.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Models.Services;
using Models.Util;
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
            var statusResultCode = await _classService.Post(newClassDTO);
            if(statusResultCode >= 400)
                return NotFound(new ApiResponse(statusResultCode, "Ocorreu um erro ao criar esta requisicao de nova classe. Verifique se os campos inseridos estao corretos e preenchidos!"));
            return Ok(new ApiResponse(statusResultCode, "Nova classe foi cadastrada com sucesso!"));
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, ClassDTO newClassDTO)
        {
            var statusResultCode = await _classService.Update(id, newClassDTO);
            if (statusResultCode >= 400)
                return NotFound(new ApiResponse(statusResultCode, "Ocorreu um erro ao tentar atualizar a base de dados, verifique se os dados inseridos estao corretos!"));
            return Ok(new ApiResponse(statusResultCode, "A classe foi atualizada com sucesso!"));

        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
             _classService.Delete(id);
            return NoContent();
        }
    }
}
