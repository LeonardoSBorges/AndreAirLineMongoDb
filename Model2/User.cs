using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Section { get; set; }
        public string Role { get; set; }

        public User(string login, string password, string section, string role, string function)
        {
            Login = login;
            Password = password;
            Section = section;
            Role = role;
        }
    }
}
