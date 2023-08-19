using Microsoft.EntityFrameworkCore;

namespace BookTracker.Models
{
    public class BookTrackerContext : DbContext
    {
        public BookTrackerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
