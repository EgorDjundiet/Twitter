using Twitter.Domain.Models;

namespace Twitter.Repository.Contracts
{
    public interface ITweetRepository
    {
        Task<IEnumerable<Tweet>> GetAll();
        Task<Tweet?> GetById(Guid id);
        Task Create(Tweet tweet);
        Task Update(Tweet tweet);
        Task Delete(Tweet tweet);
    }
}
