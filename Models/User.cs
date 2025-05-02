using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarnivalBuddyApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string GoogleId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Location { get; set; }
        public required List<string> Background { get; set; }
        public required string Image { get; set; }
        public required Song FavouriteSong { get; set; }
        public string? FavouriteCarnivalDesination { get; set; }
        public required string Bio { get; set; }
        public List<string>? ProfileImages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}