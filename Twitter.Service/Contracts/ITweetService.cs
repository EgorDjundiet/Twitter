using Twitter.Domain.Models;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Contracts
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweet>> GetAll();
        Task<Tweet> GetById(Guid id);
        Task<Tweet> Create(Guid authorId, CreatedTweet tweet);
        Task Update(Guid authorId, Guid id, UpdatedTweet tweet);
        Task Delete(Guid authorId, Guid id);
    }
}
