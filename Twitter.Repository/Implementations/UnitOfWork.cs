using Twitter.Repository.Contracts;
namespace Twitter.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly RepositoryContext _context;
        private readonly RepositoryErrorFlag _flag;
        private readonly ITweetRepository _tweetRepository;
        public UnitOfWork(RepositoryContext context, RepositoryErrorFlag flag) 
        {
            _context = context;
            _flag = flag;
            _tweetRepository = new TweetRepository(context);
        }

        public ITweetRepository TweetRepository => _tweetRepository;

        public async ValueTask DisposeAsync()
        {
            if (!_flag.Flag)
                await _context.SaveChangesAsync();
        }
    }
}
