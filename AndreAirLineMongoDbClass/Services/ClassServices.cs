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

        public async Task<int> Post(ClassDTO newClassDTO)
        {
            try
            {
                Class searchClassExists = await _classes.Find(searchClass => searchClass.Description == newClassDTO.Description).FirstOrDefaultAsync();
                if (searchClassExists == null) {
                    Class result = new Class(newClassDTO.Description, newClassDTO.Value);
                    _classes.InsertOne(result);
                    return 200;
                }
                else
                    return 404;
            }
            catch
            {

            }

            return 404;
            
        }

        public async Task<int> Update(string id, ClassDTO newClassDTO)
        {
            var resultSearchClass = _classes.Find(searchClass => searchClass.Id == id).FirstOrDefaultAsync();

            if (resultSearchClass == null)
                return 404;
            return 200;
        }
        public void Delete(string id)
        {
            _classes.DeleteOne(classes => classes.Id == id);
        }
    }
}
