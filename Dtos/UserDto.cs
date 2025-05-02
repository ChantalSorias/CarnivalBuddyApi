namespace CarnivalBuddyApi.Dtos
{
    public class UserDto
    {
        public string? Id { get; set; }
        public required string GoogleId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Location { get; set; }
        public required List<string> Background { get; set; }
        public required string Image { get; set; }
        public required SongDto FavouriteSong { get; set; }
        public string? FavouriteCarnivalDesination { get; set; }
        public required string Bio { get; set; }
        public List<string>? ProfileImages { get; set; }
    }
}