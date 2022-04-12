
using AndreAirLineMongoDbPerson.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelShare;
using ModelShare.DTO;
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

        [HttpGet("{document}")]
        public async Task<Person> Get(string document)
        {
            return await _personService.Get(document);
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
