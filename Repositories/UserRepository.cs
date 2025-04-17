using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarnivalBuddyApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);
            _usersCollection = database.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAll()
        {
            return await _usersCollection.Find(c => true).ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _usersCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _usersCollection.Find(c => c.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _usersCollection.Find(c => c.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync();
        }

        public async Task<User> Create(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return user;
        }
        public async Task Update(User user)
        {
            await _usersCollection.ReplaceOneAsync(c => c.Id == user.Id, user);
        }

        public async Task Delete(string id)
        {
            await _usersCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}