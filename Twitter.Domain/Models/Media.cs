using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Domain.Models
{
    public class Media
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Tweet))]
        public Guid TweetId { get; set; }
        public string MediaString { get; set; } = string.Empty;
    }
}
