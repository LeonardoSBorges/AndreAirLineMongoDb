using Models;
using MongoDB.Driver;

namespace AndreAirLineMongoDbBasePrice.NovaPasta
{
    public class BasePriceService
    {
        private readonly IMongoCollection<BasePrice> _basePrice;
    }
}
