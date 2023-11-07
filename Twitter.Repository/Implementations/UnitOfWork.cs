using Twitter.Repository.Contracts;
namespace Twitter.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly RepositoryContext _context;
        private readonly RepositoryErrorFlag _flag;
        private readonly ITweetRepository _tweetRepository;
        private readonly IAuthorRepository _authorRepository;
        public UnitOfWork(RepositoryContext context, RepositoryErrorFlag flag) 
        {
            _context = context;
            _flag = flag;
            _tweetRepository = new TweetRepository(context);
            _authorRepository = new AuthorRepository(context);
        }

        public ITweetRepository TweetRepository => _tweetRepository;
        public IAuthorRepository AuthorRepository => _authorRepository;

        public async ValueTask DisposeAsync()
        {
            if (!_flag.Flag)
                await _context.SaveChangesAsync();
        }
    }
}
