namespace Twitter.Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; }
        public string? Thumbnail { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Handle { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public int CountFollowing { get; set; }
        public int CountFollowers { get; set; }
        public string? Category { get; set; }
        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}
