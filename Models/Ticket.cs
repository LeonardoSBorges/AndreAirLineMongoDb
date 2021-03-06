using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public string  Reserve { get; set; }
        public Flight Flight { get; set; }
        public Person Person { get; set; }
        public BasePrice BasePrice { get; set; }
        public Class Class { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Sale { get; set; }
    }
}
