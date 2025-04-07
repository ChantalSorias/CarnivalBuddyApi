using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarnivalBuddyApi.Repositories
{
    public class CarnivalRepository : ICarnivalRepository
    {
        private readonly IMongoCollection<Carnival> _carnivalsCollection;

        public CarnivalRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);
            _carnivalsCollection = database.GetCollection<Carnival>("carnivals");
        }

        public async Task<Carnival> Create(Carnival carnival)
        {
            await _carnivalsCollection.InsertOneAsync(carnival);
            return carnival;
        }

        public async Task<List<Carnival>> GetAll()
        {
            return await _carnivalsCollection.Find(c => true).ToListAsync();
        }

        public async Task<Carnival> GetById(string id)
        {
            return await _carnivalsCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Carnival carnival)
        {
            await _carnivalsCollection.ReplaceOneAsync(c => c.Id == carnival.Id, carnival);
        }

        public async Task Delete(string id)
        {
            await _carnivalsCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}