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

        public async System.Threading.Tasks.Task AddAuthorAsync(CreateAuthorDto dto)
        {
            Author author = new Author
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Books = dto.Books.Select(b => new Book
                {
                    Title = b.Title,
                    PublishedYear = b.PublishedYear
                }).ToList()
            };

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
            return await authorsRepository.GetAuthorsWithBookCountsAsync();
        }

        public async System.Threading.Tasks.Task RemoveAuthorAsync(Guid id)
        {
            Author? author = await GetAuthorAsync(id);
            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            await authorsRepository.RemoveAuthorAsync(author!);
        }

        public async System.Threading.Tasks.Task UpdateAuthorAsync(UpdateAuthorDto dto)
        {
            Author? author = await authorsRepository.GetAuthorAsync(dto.Id);

            AuthorsValidation.EnsureAuthorIsNotEmptiness(author);
            AuthorsValidation.EnsureValidateAuthor(author!);

            author!.Name = dto.Name;
            author.DateOfBirth = dto.DateOfBirth;

            foreach (var bookDto in dto.Books)
            {
                var book = author.Books.FirstOrDefault(b => b.Id == bookDto.Id);
                if (book != null)
                {
                    book.Title = bookDto.Title;
                    book.PublishedYear = bookDto.PublishedYear;
                }
            }

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
