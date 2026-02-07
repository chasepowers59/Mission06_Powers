using System.ComponentModel.DataAnnotations;

namespace Mission06_Powers.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }   // PRIMARY KEY
        [Required]
        public string MovieName { get; set; } = string.Empty;
        [Required]
        public int MovieRating { get; set; }

        public bool IsEdited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
        [Range(0,25)]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
