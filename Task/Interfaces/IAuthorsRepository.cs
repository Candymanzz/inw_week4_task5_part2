using Task.Models;

namespace Task.Interfaces
{
    public interface IAuthorsRepository 
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author?> GetAuthorAsync(Guid id);
        System.Threading.Tasks.Task AddAuthorAsync(Author author);
        System.Threading.Tasks.Task RemoveAuthorAsync(Author author);
        System.Threading.Tasks.Task UpdateAuthorAsync(Author author);
        Task<List<Author>> FindAuthorsByNameAsync(string name);
    }
}
