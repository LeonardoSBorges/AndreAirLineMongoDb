using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class TicketDTO
    {
        public string Reserve { get; set; }
        public string FlightId { get; set; }
        public string PersonId { get; set; }
        public string BasePriceId { get; set; }
        public string ClassId { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Sale { get; set; }
    }
}
