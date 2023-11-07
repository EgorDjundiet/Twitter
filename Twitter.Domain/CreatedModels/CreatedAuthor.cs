namespace Twitter.Domain.CreatedModels
{
    public class CreatedAuthor
    {
        public string Email { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; }
        public string? Thumbnail { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Handle { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Category { get; set; }
    }
}
