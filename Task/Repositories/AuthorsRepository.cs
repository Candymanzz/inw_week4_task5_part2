using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Task.Db;
using Task.DTOs;
using Task.Interfaces;
using Task.Models;

namespace Task.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private AppDbContext appDbContext;
        
        public AuthorsRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await appDbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<Author?> GetAuthorAsync(Guid id)
        {
            return await appDbContext.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async System.Threading.Tasks.Task AddAuthorAsync(Author author)
        {
            await appDbContext.Authors.AddAsync(author);
            await appDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveAuthorAsync(Author author)
        {
            appDbContext.Authors.Remove(author);
            await appDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAuthorAsync(Author author)
        {
            appDbContext.Authors.Update(author);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<Author>> FindAuthorsByNameAsync(string name)
        {
            return await appDbContext.Authors
                .Include(a => a.Books)
                .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<AuthorDto>> GetAuthorsWithBookCountsAsync()
        {
            return await appDbContext.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    BookCount = a.Books.Count() 
                })
                .ToListAsync();
        }

    }
}
