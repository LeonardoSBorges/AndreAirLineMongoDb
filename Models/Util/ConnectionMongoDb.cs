using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    public class ConnectionMongoDb : IConnectionMongoDb
    {
        public string NameDataBase { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}
