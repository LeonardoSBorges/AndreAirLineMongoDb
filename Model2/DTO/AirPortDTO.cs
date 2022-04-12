using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare.DTO
{
    public class AirPortDTO
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public static bool VerifyExistsData(AirPortDTO airport)
        {
            if(airport.Iata == null || airport.Address.Cep == null)
            {
                return false;
            }
            return true;
        }
    }
}
