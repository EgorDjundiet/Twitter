using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;
using Twitter.Repository.Contracts;

namespace Twitter.Repository.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public AuthorRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task Create(Author author)
        {
            await _repositoryContext.Authors.AddAsync(author);
        }

        public Task Delete(Author author)
        {
            _repositoryContext.Authors.Remove(author);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _repositoryContext.Authors.Include(a => a.Tweets).ToListAsync();
        }

        public async Task<Author?> GetById(Guid id)
        {
            return await _repositoryContext.Authors.Include(a => a.Tweets).SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task Update(Author author)
        {
            _repositoryContext.Authors.Update(author);
            return Task.CompletedTask;
        }
    }
}
