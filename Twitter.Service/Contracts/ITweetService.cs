using Twitter.Domain.Models;
using Twitter.Domain.ModelsForCreation;
using Twitter.Domain.ModelsForUpdating;

namespace Twitter.Service.Contracts
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweet>> GetAll();
        Task<Tweet> GetById(Guid id);
        Task<Tweet> Create(TweetForCreationDto tweet);
        Task Update(Guid id, TweetForUpdatingDto tweet);
        Task Delete(Guid id);
    }
}
