using Task.Models;
using Task.DTOs;

namespace Task.Interfaces
{
    public interface IAuthorsService
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author?> GetAuthorAsync(Guid id);
        System.Threading.Tasks.Task AddAuthorAsync(CreateAuthorDto author);
        System.Threading.Tasks.Task RemoveAuthorAsync(Guid id);
        System.Threading.Tasks.Task UpdateAuthorAsync(UpdateAuthorDto dto);
        Task<List<AuthorDto>> GetAuthorsWithBookCountsAsync();
        Task<List<AuthorDto>> FindAuthorsByNameAsync(string name);
    }
}
