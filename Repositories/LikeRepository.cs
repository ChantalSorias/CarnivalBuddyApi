using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarnivalBuddyApi.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly IMongoCollection<Like> _likesCollection;

        public LikeRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);
            _likesCollection = database.GetCollection<Like>("likes");
        }

        public async Task<Like> GetLike(string userId, LikedEntityType entityType, string entityId)
        {
            return await _likesCollection.Find(l => l.UserId == userId && l.LikedEntityType == entityType && l.LikedEntityId == entityId).FirstOrDefaultAsync();
        }

        public async Task CreateLike(Like like)
        {
            await _likesCollection.InsertOneAsync(like);
        }

        public async Task DeleteLike(string id)
        {
            await _likesCollection.DeleteOneAsync(l => l.Id == id);
        }

        public async Task<bool> Exists(string userId, LikedEntityType entityType, string entityId)
        {
            return await _likesCollection.Find(l => l.UserId == userId && l.LikedEntityType == entityType && l.LikedEntityId == entityId).AnyAsync();
        }

        public async Task<int> GetLikesCount(LikedEntityType entityType, string entityId)
        {
            return (int)await _likesCollection.CountDocumentsAsync(l =>
                l.LikedEntityType == entityType && l.LikedEntityId == entityId);
        }

        public async Task<List<Like>> GetLikedEntityIds(string userId, LikedEntityType entityType)
        {
            return await _likesCollection.Find(l => l.UserId == userId && l.LikedEntityType == entityType).ToListAsync();
        }

    }
}