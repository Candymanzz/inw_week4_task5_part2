namespace Task.DTOs
{
    public class UpdateAuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public List<UpdateBookDto> Books { get; set; } = new();
    }
}
