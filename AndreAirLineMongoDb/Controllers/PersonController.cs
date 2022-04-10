
using AndreAirLineMongoDbPerson.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _personService.Get();
        }

        [HttpGet]
        public async Task<Person> Get(string cpf)
        {
            return await _personService.Get(cpf);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonDTO person)
        {
            var result = await _personService.Post(person);
            if (result.StatusCode <= 299)
                return Ok(result);

            return NotFound(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(string Doucument, PersonDTO person)
        {
            var result = await _personService.Replace(Doucument, person);
            if (result.StatusCode <= 299)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Doucument)
        {
            var result = await _personService.Delete(Doucument);
            if (result.StatusCode <= 299)
                return Ok(result);

            return NotFound(result);
        }
    }
}
