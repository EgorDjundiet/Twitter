using AutoMapper;
using Twitter.Domain.Models;
using Twitter.Domain.ModelsForCreation;
using Twitter.Domain.ModelsForUpdating;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TweetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Tweet> Create(TweetForCreationDto tweet)
        {
            var tweetEntity = new Tweet();
            _mapper.Map(tweet, tweetEntity);
            await _unitOfWork.TweetRepository.Create(tweetEntity);
            return tweetEntity;
        }
        public async Task Delete(Guid id)
        {
            var tweet = await GetById(id);
            await _unitOfWork.TweetRepository.Delete(tweet);
        }

        public async Task<IEnumerable<Tweet>> GetAll()
        {
            return await _unitOfWork.TweetRepository.GetAll();
        }

        public async Task<Tweet> GetById(Guid id)
        {
            var tweet = await _unitOfWork.TweetRepository.GetById(id);
            if (tweet is null)
                throw new Exception();
            return tweet;
        }

        public async Task Update(Guid id, TweetForUpdatingDto tweet)
        {
            var tweetEntity = await GetById(id);
            _mapper.Map(tweet, tweetEntity);
            await _unitOfWork.TweetRepository.Update(tweetEntity);
        }
    }
}
