namespace Task.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public DateOnly PublishedYear { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
