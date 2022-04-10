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
            var result = await _people.Find(searchPerson => true).ToListAsync();
            return result;
        }

        public async Task<Person> Get(string document)
        {
            return await _people.Find(searchPerson => searchPerson.Document == document).FirstOrDefaultAsync();
        }


        public async Task<ApiResponse> Post(PersonDTO personDTO)
        {

            Person personIn = null;
            try
            {
                if (Documents.IsCpf(personDTO.Document))
                {
                    var personExists = await _people.Find(person => person.Document == personDTO.Document).FirstOrDefaultAsync();
                    personIn = PersonIn(personDTO);

                    if (personExists != null)
                        return new ApiResponse(404, $"O registro ja existe em nossa base de dados!");

                    personIn = await SearchCep(personIn);
                    
                    _people.InsertOne(personIn);
                    return new ApiResponse(204, $"Novo registro foi inserida no banco de dados!");
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
            return new ApiResponse(404, $"Problemas ao se conectar com o servidor!");
        }

        public async Task<ApiResponse> Replace(string document, PersonDTO personIn)
        {
            
            var searchPerson = await _people.Find(person => person.Document == document).FirstOrDefaultAsync();
            if (searchPerson == null)
                return new ApiResponse(404, $"Nenhum registro foi encontrado!");
            _people.ReplaceOne(person => person.Document == document, PersonIn(personIn));
            return new ApiResponse(204, "Atualizacao de dado foi efetuada!");
        }

        public async Task<ApiResponse> Delete(string document)
        {
            try
            {
                var searchPerson = await _people.Find(person => person.Document == document).FirstOrDefaultAsync();
                if (searchPerson != null)
                {
                    var result = _people.DeleteOne(person => person.Document == document);
                    return new ApiResponse(204, $"o dado foi excluido da base de dados!");
                }
                else
                    return new ApiResponse(404, $"Nenhum dado foi encontrado, por favor verifique se o documento digitado esta correto e tente novamente!");
            }
            catch(Exception e)
            {
                var exception = e.Message;
            }
            return new ApiResponse(404);
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
