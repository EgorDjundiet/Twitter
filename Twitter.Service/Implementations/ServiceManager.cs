using AutoMapper;
using Twitter.Repository;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITweetService _tweetService;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IValidatorWrapper validator)
        {
            _tweetService = new TweetService(unitOfWork,mapper,validator);
        }
        public ITweetService TweetService => _tweetService;
    }
}
