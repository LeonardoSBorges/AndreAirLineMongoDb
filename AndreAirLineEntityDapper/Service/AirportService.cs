using AndreAirLineDapper.Models;
using AndreAirLineDapper.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineDapper.Service
{
    public class AirportService
    {
        private IAirPortRepository _airportRepository;
        
        public AirportService()
        {
            _airportRepository = new AirportRepository();
        }

        public bool Add(Airport airport)
        {
            return _airportRepository.InsertNewAirport(airport);
        }

        public async Task<List<Airport>> GetAll()
        {
            return await _airportRepository.GetAllAirports();
        }

    }
}
