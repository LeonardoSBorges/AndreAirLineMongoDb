using Models;
using Models.DTO;
using Models.Services;
using Models.Util;
using Models.Validations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbPerson.Service
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _people;
        public PersonService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _people = database.GetCollection<Person>(settings.CollectionName);
        }

        public async Task<List<Person>> Get()
        {
            return await _people.Find(searchPerson => true).ToListAsync();
        }

        public async Task<Person> Get(string document)
        {
            return await _people.Find(searchPerson => searchPerson.Document == document).FirstOrDefaultAsync();
        }


        public async Task<Person> Post(PersonDTO personDTO)
        {

            Person personIn = null;
            try
            {
                if (Documents.IsCpf(personDTO.Document))
                {
                    var personExists = await _people.Find(person => person.Document == personDTO.Document).FirstOrDefaultAsync();
                    personIn = PersonIn(personDTO);

                    if (personExists != null)
                        return personIn;

                    personIn = await SearchCep(personIn);

                    _people.InsertOne(personIn);
                    return personIn;
                }
                else
                {
                    //throw DllNotFoundException(new ApiResponse(404, $"Document not found!. (id ={personIn.Document})"));
                }

            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return personIn;
        }

        public void Replace(string document, PersonDTO personIn)
        {
            _people.ReplaceOne(person => person.Document == document, PersonIn(personIn));
        }

        public void Delete(string document)
        {
            try
            {
                _people.DeleteOne(person => person.Document == document);
            }
            catch(Exception e)
            {
                var exception = e.Message;
            }
        }

        private async Task<Person> SearchCep(Person person)
        {
            var address = await QueriesAndreAirLines.HttpCorreios(person.Address.Cep);
            address.Number = person.Address.Number;
            person.Address = address;
            return person;
        }

        private Person PersonIn(PersonDTO personDTO)
        {
            return new Person(personDTO.Document, personDTO.Name, personDTO.PhoneNumber, personDTO.Date, personDTO.Email, personDTO.Address);
        }
    }
}
