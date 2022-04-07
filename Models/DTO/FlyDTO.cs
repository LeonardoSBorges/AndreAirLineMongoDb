using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FlyDTO
    {
        public string Ticket { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public string AirPlane { get; set; }
        public DateTime BoardingTime { get; set; }
        public DateTime DisembarkationTime { get; set; }
    }
}
