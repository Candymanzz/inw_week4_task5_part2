using Task.Models;

namespace Task.Interfaces
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book?> GetBookAsync(Guid id);
        System.Threading.Tasks.Task AddBookAsync(Book book);
        System.Threading.Tasks.Task RemoveBookAsync(Book book);
        System.Threading.Tasks.Task UpdateBookAsync(Book book);
        Task<List<Book>> GetBooksPublishedAfterAsync(int year);
    }
}
