using Models;
using Models.DTO;
using Models.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbBasePrice.Services
{
    public class BasePriceService
    {
        private readonly IMongoCollection<BasePrice> _basePrice;

        public BasePriceService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _basePrice = database.GetCollection<BasePrice>(settings.CollectionName);
        }

        public async Task<List<BasePrice>> Get()
        {
            var list = await _basePrice.Find(baseprice => true).ToListAsync();
            return list;
        }

        public async Task<BasePrice> Get(string id)
        {
            BasePrice result = await _basePrice.Find(baseprice => baseprice.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<BasePrice> Post(BasePriceDTO basePriceDTO)
        {
            var newBasePrice = await BasePriceIn(basePriceDTO);
             _basePrice.InsertOne(newBasePrice);

            return newBasePrice;
        }

        //public bool Update(string id, BasePriceDTO basePriceDTO)
        //{
        //    var newBasePrice = BasePriceIn(basePriceDTO);
        //    _basePrice.ReplaceOne(basePrice => basePrice.Id == id, newBasePrice);

        //    return true;
        //}

        public async Task<BasePrice> BasePriceIn(BasePriceDTO basePriceDTO)
        {
            BasePrice resultBasePrice = new BasePrice(basePriceDTO.OriginId, basePriceDTO.DestinyId, basePriceDTO.Price, basePriceDTO.InclusionDate);
            return resultBasePrice;
        }
    }
}

