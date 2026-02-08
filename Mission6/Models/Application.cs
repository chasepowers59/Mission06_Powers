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
        public string MovieRating { get; set; } = string.Empty;


        public bool? IsEdited { get; set; }
        public string? LentTo { get; set; }
        [Range(1888, 2100)]
        [Required]
        public int Year { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
