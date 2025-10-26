namespace Task.DTOs
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public int BookCount { get; set; }
    }
}
