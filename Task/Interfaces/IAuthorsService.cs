using Task.Models;

namespace Task.Interfaces
{
    public interface IAuthorsService
    {
        List<Author> GetAuthors();
        Author? GetAuthor(Guid id);
        void AddAuthor(Author author);
        void RemoveAuthor(Guid id);
        void UpdateAuthor(Guid id, Author author);
    }
}
