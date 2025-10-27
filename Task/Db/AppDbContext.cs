using Microsoft.EntityFrameworkCore;
using Task.Db.Configuration;
using Task.Models;

namespace Task.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorsConfiguration());
            modelBuilder.ApplyConfiguration(new BooksConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
