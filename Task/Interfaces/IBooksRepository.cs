using Task.Models;

namespace Task.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetBooks();
        Book? GetBook(Guid id);
        void AddBook(Book book);
        void RemoveBook(Book book);
        void UpdateBook(Book existing, Book book);
    }
}
