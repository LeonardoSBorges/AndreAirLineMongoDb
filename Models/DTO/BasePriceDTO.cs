using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class BasePriceDTO
    {
        public string OriginId { get; set; }

        public string DestinyId { get; set; }

        public decimal Price { get; set; }

        public DateTime InclusionDate { get; set; }
    }
}
