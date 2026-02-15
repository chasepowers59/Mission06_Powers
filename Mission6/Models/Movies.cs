using System.ComponentModel.DataAnnotations;

namespace Mission06_Powers.Models
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }

        // CategoryId should NOT be required per assignment
        public int? CategoryId { get; set; }  // Changed to nullable
        public Categories? Category { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Range(1888, 2100)]
        [Required]
        public int Year { get; set; }

        // Optional fields
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        // Required by mission
        [Required]
        public bool Edited { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
    }
}