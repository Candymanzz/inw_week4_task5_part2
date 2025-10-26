using Task.Interfaces;
using Task.Models;
using Task.Validations;

namespace Task.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private List<Author> authors = new();

        public List<Author> GetAuthors()
        {
            return authors;
        }

        public Author? GetAuthor(Guid id)
        {
            return authors.FirstOrDefault(a => a.Id == id);
        }

        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }

        public void RemoveAuthor(Author author)
        {
            authors.Remove(author!);
        }

        public void UpdateAuthor(Author existing, Author author)
        {
            existing!.Name = author.Name;
            existing!.DateOfBirth = author.DateOfBirth;
        }
    }
}
