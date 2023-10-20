using Twitter.Domain.Models;

namespace Twitter.Domain.ModelsForUpdating
{
    public class TweetForUpdatingDto
    {
        public string? Text { get; set; }
        public List<string>? Medias { get; set; }
        public Dictionary<string,int>? PollItems { get; set; }
        public DateTime? Schedule { get; set; }
    }
}
