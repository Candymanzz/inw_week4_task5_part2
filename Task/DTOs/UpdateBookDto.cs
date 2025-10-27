namespace Task.DTOs
{
    public class UpdateBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly PublishedYear { get; set; }
        public Guid AuthorId { get; set; }
    }
}
