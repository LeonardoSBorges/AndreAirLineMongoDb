using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineDapper.Repository
{
    public interface IAirPortRepository
    {
        bool InsertNewAirport(Airport airport);
        Task<List<Airport>> GetAllAirports();

    }
}
