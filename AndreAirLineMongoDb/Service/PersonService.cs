using AndreAirLinesWebApplication.Service;
using Models;
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
        public PersonService(ConnectionMongoDb settings)
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

        public async Task<Person> Post(Person person)
        {
            try
            {
                if (Documents.IsCpf(person.Document))
                {
                    var address = await QueryAddressService.HTTPCorreios(person.Address.Cep);

                    person = address != null ? updateData(address, person) : person;

                    _people.InsertOne(person);
                    return person;
                }
                else
                    
            }
            catch
            {

            }
            return null;
        }

      

        public bool Replace(string document, Person person)
        {
            _people.ReplaceOne()

            return true
        }



        private Person updateData(Address address, Person person)
        {
            address.Number = person.Address.Number;
            person.Address = address;
            return person;
        }
    }
}
