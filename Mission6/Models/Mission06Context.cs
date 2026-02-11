using Microsoft.EntityFrameworkCore;

namespace Mission06_Powers.Models
{
    public class Mission06Context : DbContext
    {
        public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; } = null!;
        public DbSet<Categories> Categories { get; set; } = null!;
    }
}
