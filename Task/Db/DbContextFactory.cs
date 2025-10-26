using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Task.Db
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            dbContextOptionsBuilder.UseSqlite("Data Source=task5.db");

            return new AppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
