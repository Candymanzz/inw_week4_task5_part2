using Task.DTOs;
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

        public async System.Threading.Tasks.Task AddAuthorAsync(Author author)
        {
            AuthorsValidation.EnsureValidateAuthor(author);
            await authorsRepository.AddAuthorAsync(author);
        }

        public async Task<Author?> GetAuthorAsync(Guid id)
        {
            AuthorsValidation.EnsureValidateId(id);
            return await authorsRepository.GetAuthorAsync(id);
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await authorsRepository.GetAuthorsAsync();
        }

        public async Task<List<AuthorDto>> GetAuthorsWithBookCountsAsync()
        {
            List<Author> authors = await authorsRepository.GetAuthorsAsync();
                
            List<AuthorDto> authorsWhithCountOfBooks = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                BookCount = a.Books?.Count ?? 0
            }).ToList();

            return authorsWhithCountOfBooks;
        }

        public async System.Threading.Tasks.Task RemoveAuthorAsync(Guid id)
        {
            Author? author = await GetAuthorAsync(id);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            await authorsRepository.RemoveAuthorAsync(author!);
        }

        public async System.Threading.Tasks.Task UpdateAuthorAsync (Author author)
        {
            AuthorsValidation.EnsureValidateAuthor(author);
            Author? existing = await authorsRepository.GetAuthorAsync(author.Id);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(existing);

            await authorsRepository.UpdateAuthorAsync(author);
        }

        public async Task<List<AuthorDto>> FindAuthorsByNameAsync(string name)
        {
            AuthorsValidation.EnsureParameterIsNotEmptiness(name);

            var authors = await authorsRepository.FindAuthorsByNameAsync(name);

            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                BookCount = a.Books.Count
            }).ToList();
        }
    }
}
