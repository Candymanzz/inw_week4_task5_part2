using Task.DTOs;
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

        public async System.Threading.Tasks.Task AddBookAsync(Book book)
        {
            AuthorsValidation.EnsureValidateId(book.Id);
            Author? author = await authorsRepository.GetAuthorAsync(book.AuthorId);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            BooksValidation.EnsureValidateBook(book);
            await booksRepository.AddBookAsync(book);
        }

        public async Task<Book?> GetBookAsync(Guid id)
        {
            BooksValidation.EnsureValidateId(id);
            return await booksRepository.GetBookAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await booksRepository.GetBooksAsync();
        }

        public async Task<List<BookDto>> GetBooksPublishedAfterAsync(int year)
        {
            List<Book> books = await booksRepository.GetBooksPublishedAfterAsync(year);

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublishedYear = b.PublishedYear.Year,
                AuthorName = b.Author.Name
            }).ToList();
        }

        public async System.Threading.Tasks.Task RemoveBookAsync(Guid id)
        {
            Book? book = await GetBookAsync(id);
            BooksValidation.EnsureBookIsNotEmptiness(book);
            await booksRepository.RemoveBookAsync(book!);
        }

        public async System.Threading.Tasks.Task UpdateBookAsync(Book book)
        {
            Author? author = await authorsRepository.GetAuthorAsync(book.AuthorId);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            BooksValidation.EnsureValidateBook(book);
            var existing = await booksRepository.GetBookAsync(book.Id);
            BooksValidation.EnsureBookIsNotEmptiness(existing);
            await booksRepository.UpdateBookAsync(book);
        }
    }
}
