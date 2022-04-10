using Microsoft.AspNetCore.Mvc;
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

        public ApiResponse Update(BasePrice basePrice)
        {
            try {

                if (basePrice.OriginId == basePrice.DestinyId)
                    return new ApiResponse(400, $"Nao foi possivel alterar os destinos pois os que estao sendo atualizados ficaram iguais, por favor verifique e tente novamente!");
                var basePriceExists = _basePrice.Find(baseprice => baseprice.Id == basePrice.Id).FirstOrDefault();
                if (basePriceExists == null)
                    return new ApiResponse(404, $"Nenhum dado foi encontrado!");

                _basePrice.ReplaceOne(baseprice => baseprice.Id == basePrice.Id, basePrice);
                return new ApiResponse(204, $"Alteracao efetuada com sucesso!");
            }
            catch
            {
                
            }
            return new ApiResponse(400, $"Erro ao tentar se conectar ao banco de dados, por favor contate o suporte de TI!");
        }
        public ApiResponse Delete(string id)
        {
            try
            {
                var searchBasePrice = _basePrice.Find(searchBasePriceIn => searchBasePriceIn.Id == id).FirstOrDefault();
                if (searchBasePrice == null)
                    return new ApiResponse(404, $"Nao foi encontrado nenhum item com este Id na base de dados, por favor verifique e tente novamente!");
                _basePrice.DeleteOne(searchBasePrice => searchBasePrice.Id == id);
                return new ApiResponse(204, $"Requisicao atendida, o item foi excluido da base de dados!");
            }
            catch
            {

            }

            return null; 
        }

        public async Task<BasePrice> BasePriceIn(BasePriceDTO basePriceDTO)
        {
            BasePrice resultBasePrice = new BasePrice(basePriceDTO.OriginId, basePriceDTO.DestinyId, basePriceDTO.Price, basePriceDTO.InclusionDate);
            return resultBasePrice;
        }
    }
}

