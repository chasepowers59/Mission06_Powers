using System.ComponentModel.DataAnnotations;

namespace Mission06_Powers.Models
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Categories? Category { get; set; } // instance of the class, saying the CategoryId links to a name in another table

        [Required]
        public string Title { get; set; } = string.Empty;

        [Range(1888, 2100)]
        [Required]
        public int Year { get; set; }

        // These are nullable in the provided DB (your data shows Director can be blank)
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        // Required by mission for new entries
        [Required]
        public bool Edited { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
    }
}
