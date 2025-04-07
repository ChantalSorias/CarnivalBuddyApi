using System.ComponentModel.DataAnnotations;

namespace CarnivalBuddyApi.Dtos
{
    public class LinkDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Url { get; set; }
    }
}