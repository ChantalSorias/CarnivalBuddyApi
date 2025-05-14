using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Services.Interfaces
{
    public interface ILikeService
    {
        Task<bool> Like(string userId, LikedEntityType entityType, string entityId);
        Task<bool> Unlike(string userId, LikedEntityType entityType, string entityId);
        Task<bool> IsLiked(string userId, LikedEntityType entityType, string entityId);
        Task<int> GetLikesCount(LikedEntityType entityType, string entityId);
        Task<List<string>> GetLikedEntityIds(string userId, LikedEntityType entityType);
    }
}