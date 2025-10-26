using Task.Models;
using Task.Interfaces;
using Task.Validations;

namespace Task.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> books = new();

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book? GetBook(Guid id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void UpdateBook(Book existing, Book book)
        {
            existing.Title = book.Title;
            existing.PublishedYear = book.PublishedYear;
            existing.AuthorId = book.AuthorId;
        }
    }
}
