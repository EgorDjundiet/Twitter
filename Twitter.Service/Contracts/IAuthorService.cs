using Twitter.Domain.CreatedModels;
using Twitter.Domain.Models;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(Guid id);
        Task<Author> Create(CreatedAuthor author);
        Task Update(Guid id, UpdatedAuthor author);
        Task Delete(Guid id);
    }
}
