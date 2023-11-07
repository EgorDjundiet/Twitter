using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;
using Twitter.Repository.Contracts;

namespace Twitter.Repository.Implementations
{
    public class TweetRepository : ITweetRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public TweetRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task Create(Tweet tweet)
        {
            await _repositoryContext.Tweets.AddAsync(tweet);
        }

        public Task Delete(Tweet tweet)
        {
            _repositoryContext.Tweets.Remove(tweet);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Tweet>> GetAll()
        {
            var tweets = await _repositoryContext.Tweets.Include(t => t.Medias).Include(t => t.PollItems).ToListAsync();
            return tweets;
        }

        public async Task<Tweet?> GetById(Guid id)
        {
            var tweet = await _repositoryContext.Tweets.Include(t => t.Medias).Include(t => t.PollItems).Where(x => x.Id == id).SingleOrDefaultAsync();
            return tweet;
        }

        public Task Update(Tweet tweet)
        {
            _repositoryContext.Tweets.Update(tweet);
            return Task.CompletedTask;
        }
    }
}
