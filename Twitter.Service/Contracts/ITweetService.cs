using Twitter.Domain.Models;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Contracts
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweet>> GetAll();
        Task<Tweet> GetById(Guid id);
        Task<Tweet> Create(CreatedTweet tweet);
        Task Update(Guid id, UpdatedTweet tweet);
        Task Delete(Guid id);
    }
}
