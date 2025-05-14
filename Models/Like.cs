using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarnivalBuddyApi.Models
{
    public class Like
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string UserId { get; set; }
        public User? User { get; set; }
        public required LikedEntityType LikedEntityType { get; set; }
        public required string LikedEntityId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum LikedEntityType
    {
        Carnival,
        Post
    }
}