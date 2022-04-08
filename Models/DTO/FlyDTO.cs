using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FlyDTO
    {
        [DataMember]
        public string Ticket { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string Destiny { get; set; }
        [DataMember]
        public string AirPlane { get; set; }
        [DataMember]
        public DateTime BoardingTime { get; set; }
        [DataMember]
        public DateTime DisembarkationTime { get; set; }
    }
}
