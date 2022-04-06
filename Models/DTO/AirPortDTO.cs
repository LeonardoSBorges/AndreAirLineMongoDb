using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AirPortDTO
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
