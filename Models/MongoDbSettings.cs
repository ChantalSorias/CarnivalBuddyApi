namespace CarnivalBuddyApi.Models
{
    public class MongoDbSettings
    {
        public required string ConnectionString { get; set; }
        public required string Database { get; set; }
    }
}