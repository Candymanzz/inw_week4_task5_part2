namespace Task.DTOs
{
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public List<CreateBookDto> Books { get; set; } = new();
    }
}
