using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public string Password { get; set; }
        public string Login { get; set; }
        public string Section { get; set; }
        public Function Function { get; set; }
    }
}
