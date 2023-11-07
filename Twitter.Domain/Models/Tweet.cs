namespace Twitter.Domain.Models
{
    public class Tweet
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public List<Media> Medias { get; set; } = new List<Media>();
        public List<PollItem> PollItems { get; set; } = new List<PollItem>();

        public DateTime TweetDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime? Schedule { get; set; }

        public int CountReplies { get; set; }

        public int CountReposts { get; set; }

        public int CountLikes { get; set; }

        public int CountViews { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorHandle { get; set; } = string.Empty;
        public string? AuthorProfilePicture { get; set; }
    }
}
