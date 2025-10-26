using Task.Models;
using Task.DTOs;

namespace Task.Interfaces
{
    public interface IAuthorsService
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author?> GetAuthorAsync(Guid id);
        System.Threading.Tasks.Task AddAuthorAsync(Author author);
        System.Threading.Tasks.Task RemoveAuthorAsync(Guid id);
        System.Threading.Tasks.Task UpdateAuthorAsync(Author author);
        Task<List<AuthorDto>> GetAuthorsWithBookCountsAsync();
        Task<List<AuthorDto>> FindAuthorsByNameAsync(string name);
    }
}
