using System.ComponentModel.DataAnnotations.Schema;
namespace Twitter.Domain.Models
{
    public class PollItem
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Tweet))]
        public Guid TweetId { get; set; }
        public string Choice { get; set; } = string.Empty;
        public int CountVoices { get; set; }
    }
}
