namespace Twitter.Domain.UpdatedModels
{
    public class UpdatedTweet
    {
        public string? Text { get; set; }
        public List<string>? Medias { get; set; }
        public List<string>? PollItems { get; set; }
        public DateTime? Schedule { get; set; }
    }
}
