using AutoMapper;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITweetService _tweetService;
        private readonly IAuthorService _authorService;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IValidatorWrapper validator)
        {
            _tweetService = new TweetService(unitOfWork,mapper,validator);
            _authorService = new AuthorService(unitOfWork,mapper,validator);
        }
        public ITweetService TweetService => _tweetService;
        public IAuthorService AuthorService => _authorService;
    }
}
