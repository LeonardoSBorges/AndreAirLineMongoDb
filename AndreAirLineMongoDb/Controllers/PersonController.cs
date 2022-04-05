using AndreAirLineMongoDbPerson.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        public ActionResult<Person> Post(Person person)
        {
            _personService.Post(person);
            return person;
        }
        [HttpPut]
        public IActionResult Put(string cpf, Person person)
        {
            _personService.Replace(cpf, person);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string cpf)
        {
            _personService.Delete(cpf);
            return NoContent();
        }
    }
}
