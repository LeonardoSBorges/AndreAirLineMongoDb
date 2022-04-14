using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare.Util
{
    public class ConnectionMongoDb : IConnectionMongoDb
    {
        public string NameDataBase { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }

        public ConnectionMongoDb()
        {

        }

        public ConnectionMongoDb(string nameDataBase, string collectionName, string connectionString)
        {
            NameDataBase = nameDataBase;
            CollectionName = collectionName;
            ConnectionString = connectionString;
        }
    }
}
