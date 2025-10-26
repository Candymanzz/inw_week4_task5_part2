using Task.Models;

namespace Task.Validations
{
    public static class AuthorsValidation
    {
        public static void EnsureValidateId(Guid id)
        {
            if (id.ToString().Length != 36)
            {
                throw new ArgumentException("Invalid author id");
            }
        }

        public static void EnsureValidateAuthor(Author author)
        {
            bool dateValid = author.DateOfBirth < DateOnly.FromDateTime(DateTime.Now);
            bool nameIsNotEmpty = author.Name.Length > 0;

            if (!dateValid && !nameIsNotEmpty)
            {
                throw new ArgumentException("Invalid author");
            }
        }

        public static void EnsureAuthorIsNotEmptiness(Author? author)
        {
            if (author is null)
            {
                throw new ArgumentException("Author is empty");
            }
        }
    }
}
