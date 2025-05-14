using System.ComponentModel.DataAnnotations;

namespace CarnivalBuddyApi.Dtos
{
    public class CarnivalDto
    {
        public string? Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Title { get; set; }
        [Required]
        [StringLength(500)]
        public required string Description { get; set; }
        [Required]
        [StringLength(100)]
        public required string Location { get; set; }
        [Required]
        public required List<DateTime> ParadeDates { get; set; }
        public string? Image { get; set; }
        public bool Liked { get; set; }
        public required List<LinkDto> Links { get; set; }
    }
}