using Task.Models;

namespace Task.Interfaces
{
    public interface IAuthorsRepository 
    {
        List<Author> GetAuthors();
        Author? GetAuthor(Guid id);
        void AddAuthor(Author author);
        void RemoveAuthor(Author author);
        void UpdateAuthor(Author existing, Author author);
    }
}
