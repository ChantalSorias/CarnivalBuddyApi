using CarnivalBuddyApi.Models;

namespace CarnivalBuddyApi.Dtos
{
    public class LikeDto
    {
        public required LikedEntityType EntityType { get; set; }
        public required string EntityId { get; set; }
    }
}