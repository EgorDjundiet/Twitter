namespace Twitter.Service.Contracts
{
    public interface IServiceManager
    {
        ITweetService TweetService { get; }
        IAuthorService AuthorService { get; }
    }
}
