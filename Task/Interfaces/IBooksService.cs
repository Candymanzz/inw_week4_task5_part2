using Task.Models;

namespace Task.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetBooks();
        Book? GetBook(Guid id);
        void AddBook(Book book);
        void RemoveBook(Guid id);
        void UpdateBook(Guid id, Book book);
    }
}
