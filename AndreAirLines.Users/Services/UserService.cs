using ModelShare;
using ModelShare.DTO;
using ModelShare.Util;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndreAirLines.Users.Services
{
    public class UserService
    {

        private readonly IMongoCollection<User> _user;

        public UserService(IConnectionMongoDb settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.NameDataBase);
            _user = database.GetCollection<User>(settings.CollectionName);
        }

        public async Task<ICollection<User>> GetAllUsers() =>
            await _user.Find(seachUsers => true).ToListAsync();

        public async Task<User> GetUser(string login, string password) =>
            await _user.Find(searchUsers => searchUsers.Login == login && searchUsers.Password == password).FirstOrDefaultAsync();


        public async Task<User> PostNewUser(UserDTO userDTO)
        {
            User user = new User(userDTO.Login, userDTO.Password,userDTO.Section ,userDTO.Role, userDTO.functionName);
            var userExist = await _user.Find(searchUser => searchUser.Login == user.Login).FirstOrDefaultAsync();
            if (userExist != null)
                return userExist;
            _user.InsertOne(user);
            return user;
        }
    }
}
