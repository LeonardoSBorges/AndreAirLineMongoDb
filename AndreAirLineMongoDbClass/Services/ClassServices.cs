using Models;
using Models.DTO;
using Models.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbClass.Services
{
    public class ClassServices
    {
        private readonly IMongoCollection<Class> _classes;

        public ClassServices(IConnectionMongoDb settings)
        {
            var service = new MongoClient(settings.ConnectionString);
            var database = service.GetDatabase(settings.NameDataBase);
            _classes = database.GetCollection<Class>(settings.CollectionName);
        }

        public async Task<List<Class>> GetAll()
        {
            return await _classes.Find(classes => true).ToListAsync();
        }

        public async Task<Class> Get(string id)
        {
            var resultSearchClasses = await _classes.Find(classes => classes.Id == id).FirstOrDefaultAsync();
            return resultSearchClasses;
        }

        public async Task<ApiResponse> Post(ClassDTO newClassDTO)
        {
            try
            {
                var searchClassExists = await _classes.Find(searchClass => searchClass.Description == newClassDTO.Description).FirstOrDefaultAsync();
                if (searchClassExists == null) {
                    Class result = new Class(newClassDTO.Description, newClassDTO.Value);
                    _classes.InsertOne(result);
                    return new ApiResponse(204, $"Nova classe inserida!");
                }
                else
                    return new ApiResponse(404, $"Nenhum dado encontrado!");
            }
            catch
            {

            }

            return new ApiResponse(400, $"Erro ao tentar se conectar ao banco de dados, por favor contate o suporte de TI!");
            
        }

        public async Task<ApiResponse> Update(Class replaceClass)
        {
            try
            {
                var resultSearchClass = await _classes.Find(searchClass => searchClass.Id == replaceClass.Id).FirstOrDefaultAsync();

                if (resultSearchClass == null)
                    return new ApiResponse(404, $"Nenhum dado encontrado!");

                _classes.ReplaceOne(searchData => searchData.Id == replaceClass.Id, replaceClass);
                return new ApiResponse(204, $"Dado atualizado com sucesso!");
            }
            catch
            {

            }
            return new ApiResponse(400, $"Erro ao tentar se conectar ao banco de dados, por favor contate o suporte de TI!");
        }
        public ApiResponse Delete(string id)
        {
            var searchItem = _classes.Find(searchClass => searchClass.Id == id).FirstOrDefault();
            if (searchItem == null)
                return new ApiResponse(404, $"Nenhum dado encontrado!");
            _classes.DeleteOne(classes => classes.Id == id);
            return new ApiResponse(204, $"Dado excluido com sucesso!");
        }
    }
}
