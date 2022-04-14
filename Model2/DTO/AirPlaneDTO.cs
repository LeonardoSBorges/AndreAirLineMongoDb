using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare.DTO
{
    public class AirPlaneDTO
    {
        public string Enrollment { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public AirPlaneDTO()
        {

        }

        public AirPlaneDTO(string enrollment, string name, int capacity)
        {
            Enrollment = enrollment;
            Name = name;
            Capacity = capacity;
        }
    }
}
