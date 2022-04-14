using ModelShare;
using ModelShare.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLineMongoDbAirPlane.Service
{
    public interface IAirplaneService
    {
        Task<List<AirPlane>> Get();


        Task<AirPlane> Get(string enrollment);

        Task<dynamic> Post(AirPlaneDTO airPlaneDTO);

        Task Put(AirPlaneDTO airPlaneDTO);


        Task Delete(string enrollment);
       
    }
}
