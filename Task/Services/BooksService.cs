using Task.Interfaces;
using Task.Models;
using Task.Validations;

namespace Task.Services
{
    public class BooksService : IBooksService
    {
        private IBooksRepository booksRepository;
        private IAuthorsRepository authorsRepository;

        public BooksService(IBooksRepository booksRepository, IAuthorsRepository authorsRepository)
        {
            this.booksRepository = booksRepository;
            this.authorsRepository = authorsRepository;
        }

        public void AddBook(Book book)
        {
            AuthorsValidation.EnsureValidateId(book.Id);
            Author? author = authorsRepository.GetAuthor(book.AuthorId);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            BooksValidation.EnsureValidateBook(book);
            booksRepository.AddBook(book);
        }

        public Book? GetBook(Guid id)
        {
            BooksValidation.EnsureValidateId(id);
            return booksRepository.GetBook(id);
        }

        public List<Book> GetBooks()
        {
            return booksRepository.GetBooks();
        }

        public void RemoveBook(Guid id)
        {
            Book? book = GetBook(id);
            BooksValidation.EnsureBookIsNotEmptiness(book);
            booksRepository.RemoveBook(book!);
        }

        public void UpdateBook(Guid id, Book book)
        {
            Book? existing = GetBook(id);
            Author? author = authorsRepository.GetAuthor(book.AuthorId);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            BooksValidation.EnsureBookIsNotEmptiness(existing);
            BooksValidation.EnsureValidateBook(book);
            booksRepository.UpdateBook(existing!, book);
        }
    }
}
