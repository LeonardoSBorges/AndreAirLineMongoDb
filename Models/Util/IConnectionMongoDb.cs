using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    interface IConnectionMongoDb
    {
        string NameDataBase { get; set; }
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
    }
}
