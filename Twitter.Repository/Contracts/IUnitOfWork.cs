namespace Twitter.Repository.Contracts
{
    public interface IUnitOfWork
    {
        ITweetRepository TweetRepository { get; }
        IAuthorRepository AuthorRepository { get; }
    }
}
