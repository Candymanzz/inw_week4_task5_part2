using Task.DTOs;
using Task.Models;

namespace Task.Interfaces
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book?> GetBookAsync(Guid id);
        System.Threading.Tasks.Task AddBookAsync(CreateBookDto dto);
        System.Threading.Tasks.Task RemoveBookAsync(Guid id);
        System.Threading.Tasks.Task UpdateBookAsync(Book book);
        Task<List<BookDto>> GetBooksPublishedAfterAsync(int year);
    }
}
