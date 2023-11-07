using Twitter.Domain.Models;

namespace Twitter.Repository.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task Create(Author author);
        Task Update(Author author);
        Task Delete(Author author);
    }
}
