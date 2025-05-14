using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> GetLike(string userId, LikedEntityType entityType, string entityId);
        Task CreateLike(Like like);
        Task DeleteLike(string id);
        Task<bool> Exists(string userId, LikedEntityType entityType, string entityId);
        Task<int> GetLikesCount(LikedEntityType entityType, string entityId);
        Task<List<Like>> GetLikedEntityIds(string userId, LikedEntityType entityType);
    }
}