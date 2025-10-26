using Task.Interfaces;
using Task.Models;
using Task.Validations;

namespace Task.Services
{
    public class AuthorsService : IAuthorsService
    {
        private IAuthorsRepository authorsRepository;
        public AuthorsService(IAuthorsRepository authorsRepository) 
        {
            this.authorsRepository = authorsRepository;
        }

        public void AddAuthor(Author author)
        {
            AuthorsValidation.EnsureValidateAuthor(author);
            authorsRepository.AddAuthor(author);
        }

        public Author? GetAuthor(Guid id)
        {
            AuthorsValidation.EnsureValidateId(id);
            return authorsRepository.GetAuthor(id);
        }

        public List<Author> GetAuthors()
        {
            return authorsRepository.GetAuthors();
        }

        public void RemoveAuthor(Guid id)
        {
            Author? author = GetAuthor(id);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            authorsRepository.RemoveAuthor(author!);
        }

        public void UpdateAuthor(Guid id, Author author)
        {
            Author? existing = GetAuthor(id);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(existing);
            AuthorsValidation.EnsureValidateAuthor(author);
            authorsRepository.UpdateAuthor(existing!, author);
        }
    }
}
