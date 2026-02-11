using System.ComponentModel.DataAnnotations;

namespace Mission06_Powers.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }   // PRIMARY KEY
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        // navigation
        public ICollection<Movies> Movies { get; set; } = new List<Movies>();

    }
}
