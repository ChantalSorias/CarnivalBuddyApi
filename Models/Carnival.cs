using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarnivalBuddyApi.Models
{
    public class Carnival
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required List<DateTime> ParadeDates { get; set; }
        public string? Image { get; set; }
        public required List<Link> Links { get; set; }
        [BsonIgnore]
        public bool Liked { get; set; }
    }
}