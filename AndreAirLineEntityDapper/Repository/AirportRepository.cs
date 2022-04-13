using AndreAirLineDapper.Config;
using Dapper;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AndreAirLineDapper.Repository
{

    public class AirportRepository : IAirPortRepository
    {
        private readonly string _connection;

        public AirportRepository()
        {
            _connection = DataBaseConfig.Get();
        }

        public bool InsertNewAirport(Airport airport)
        {
            using (var db = new SqlConnection(_connection))
            {
                db.Open();
                var registerAirports = db.Execute(Airport.INSERT, airport);
                return true;
            }
        }

        public async Task<List<Airport>> GetAllAirports()
        {
            using (var db = new SqlConnection(_connection))
            {
                db.Open();
                var getAirports = db.Query<Airport>(Airport.GETALL);
                db.Close();
                return (List<Airport>)getAirports;
            }
        }

    }
}
