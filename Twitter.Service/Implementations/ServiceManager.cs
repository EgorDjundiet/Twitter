using AutoMapper;
using Twitter.Repository;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITweetService _tweetService;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tweetService = new TweetService(unitOfWork,mapper);
        }
        public ITweetService TweetService => _tweetService;
    }
}
