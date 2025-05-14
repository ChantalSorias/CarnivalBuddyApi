using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Repositories.Interfaces;
using CarnivalBuddyApi.Services.Interfaces;

namespace CarnivalBuddyApi.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public async Task<bool> IsLiked(string userId, LikedEntityType entityType, string entityId)
        {
            return await _likeRepository.Exists(userId, entityType, entityId);
        }

        public async Task<bool> Like(string userId, LikedEntityType entityType, string entityId)
        {
            var exists = await _likeRepository.Exists(userId, entityType, entityId);
            if (exists) return false;

            var like = new Like
            {
                UserId = userId,
                LikedEntityType = entityType,
                LikedEntityId = entityId
            };

            await _likeRepository.CreateLike(like);
            return true;
        }

        public async Task<bool> Unlike(string userId, LikedEntityType entityType, string entityId)
        {
            var like = await _likeRepository.GetLike(userId, entityType, entityId);
            if (like == null)
            {
                return false;
            }

            await _likeRepository.DeleteLike(like.Id!);
            return true;
        }

        public async Task<int> GetLikesCount(LikedEntityType entityType, string entityId)
        {
            return await _likeRepository.GetLikesCount(entityType, entityId);
        }

        public async Task<List<string>> GetLikedEntityIds(string userId, LikedEntityType entityType)
        {
            var likes = await _likeRepository.GetLikedEntityIds(userId, entityType);
            return likes.Select(l => l.LikedEntityId).ToList();
        }
    }
}