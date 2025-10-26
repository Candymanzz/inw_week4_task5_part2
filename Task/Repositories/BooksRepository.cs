using Task.Models;
using Task.Interfaces;
using Task.Validations;
using Task.Db;
using Microsoft.EntityFrameworkCore;

namespace Task.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private AppDbContext appDbContext;

        public BooksRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await appDbContext.Books.Include(b => b.Author).AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookAsync(Guid id)
        {
            return await appDbContext.Books.Include(b => b.Author).AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async System.Threading.Tasks.Task AddBookAsync(Book book)
        {
            await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveBookAsync(Book book)
        {
            appDbContext.Books.Remove(book);
            await appDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateBookAsync(Book book)
        {
            appDbContext.Update(book);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksPublishedAfterAsync(int year)
        {
            return await appDbContext.Books.Include(b => b.Author)
                .Where(b => b.PublishedYear.Year > year)
                .AsNoTracking().ToListAsync();
        }
    }
}
