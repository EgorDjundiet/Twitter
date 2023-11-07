using AutoMapper;
using Twitter.Domain.Exceptions;
using Twitter.Domain.Models;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidatorWrapper _validator;
        public TweetService(IUnitOfWork unitOfWork, IMapper mapper, IValidatorWrapper validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Tweet> Create(Guid authorId, CreatedTweet tweet)
        {
            var author = await CheckAuthorForExistence(authorId);
            var validationResult = _validator.CreatedTweetValidator.Validate(tweet);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            
            var tweetEntity = new Tweet();
            _mapper.Map(tweet, tweetEntity);
            tweetEntity.AuthorName = author.Name;
            tweetEntity.AuthorHandle = author.Handle;
            tweetEntity.AuthorProfilePicture = author.ProfilePicture;
            await _unitOfWork.TweetRepository.Create(tweetEntity);
            return tweetEntity;
        }
        public async Task Delete(Guid authorId, Guid id)
        {
            await CheckAuthorForExistence(authorId);
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
                throw new NotFoundException($"Tweet with id {id} is not found");
            return tweet;
        }

        public async Task Update(Guid authorId, Guid id, UpdatedTweet tweet)
        {
            var author = await CheckAuthorForExistence(authorId);
            var validationResult = _validator.UpdatedTweetValidator.Validate(tweet);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            
            var tweetEntity = await GetById(id);
            _mapper.Map(tweet, tweetEntity);
            await _unitOfWork.TweetRepository.Update(tweetEntity);
        }

        private async Task<Author> CheckAuthorForExistence(Guid authorId)
        {
            var author = await _unitOfWork.AuthorRepository.GetById(authorId);
            if(author is null)
            {
                throw new NotFoundException($"Author with {authorId} doesn't exist");
            }
            return author;
        }
    }
}
