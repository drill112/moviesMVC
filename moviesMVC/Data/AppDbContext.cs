using Microsoft.EntityFrameworkCore;
using moviesMVC.Models;

namespace moviesMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies => Set<Movie>();
    }
}
