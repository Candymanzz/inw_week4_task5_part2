namespace Task.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public DateOnly PublishedYear { get; set; }
        public Guid AuthorId { get; set; }
    }
}
