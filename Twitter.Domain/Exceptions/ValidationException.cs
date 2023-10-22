namespace Twitter.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Messages { get; set; }
        public ValidationException(IEnumerable<string> messages) : base("Validation error")
        {
            Messages = messages;
        }
    }
}
