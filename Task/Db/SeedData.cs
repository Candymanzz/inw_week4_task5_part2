using Task.Models;

namespace Task.Db
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext appDbContext)
        {
            if (appDbContext.Authors.Any()) return;

            var authors = new List<Author>
            {
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Leo Tolstoy",
                    DateOfBirth = new DateOnly(1828, 9, 9),
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "War and Peace",
                            PublishedYear = new DateOnly(1869, 1, 1)
                        },
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "Anna Karenina",
                            PublishedYear = new DateOnly(1877, 1, 1)
                        }
                    }
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Fyodor Dostoevsky",
                    DateOfBirth = new DateOnly(1821, 11, 11),
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "Crime and Punishment",
                            PublishedYear = new DateOnly(1866, 1, 1)
                        },
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "The Idiot",
                            PublishedYear = new DateOnly(1869, 1, 1)
                        }
                    }
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "George Orwell",
                    DateOfBirth = new DateOnly(1903, 6, 25),
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "1984",
                            PublishedYear = new DateOnly(1949, 6, 8)
                        },
                        new Book
                        {
                            Id = Guid.NewGuid(),
                            Title = "Animal Farm",
                            PublishedYear = new DateOnly(1945, 8, 17)
                        }
                    }
                }
            };

            appDbContext.Authors.AddRange(authors);
            appDbContext.SaveChanges();
        }
    }
}
