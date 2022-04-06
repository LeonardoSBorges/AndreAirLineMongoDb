
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

        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<Person> Get(string cpf)
        {
            return await _personService.Get(cpf);
        }

        [HttpPost]
        public async Task<Person> Post(PersonDTO person)
        {
            return await _personService.Post(person);
        }
        [HttpPut]
        public IActionResult Put(string Doucument, PersonDTO person)
        {
            _personService.Replace(Doucument, person);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string Doucument)
        {
            _personService.Delete(Doucument);
            return NoContent();
        }
    }
}
