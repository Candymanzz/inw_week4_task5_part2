using Task.Models;

namespace Task.Validations
{
    public static class BooksValidation
    {
        public static void EnsureValidateId(Guid id)
        {
            if (id.ToString().Length != 36)
            {
                throw new ArgumentException("Invalid book id");
            }
        }

        public static void EnsureValidateBook(Book book)
        {
            bool titleIsNotEmpty = book.Title.Length > 0;
            bool dateValid = book.PublishedYear < DateOnly.FromDateTime(DateTime.Now);

            if (!titleIsNotEmpty && !dateValid)
            {
                throw new ArgumentException("Invalid book");
            }
        }

        public static void EnsureBookIsNotEmptiness(Book? book)
        {
            if (book is null)
            {
                throw new ArgumentException("Author is empty");
            }
        }
    }
}
