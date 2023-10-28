namespace Twitter.Domain.Models
{
    public class PollItem
    {
        public Guid Id { get; set; }
        public string Choice { get; set; } = string.Empty;
        public int CountVoices { get; set; }
    }
}
