using AutoMapper;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.Exceptions;
using Twitter.Domain.Models;
using Twitter.Domain.UpdatedModels;
using Twitter.Repository.Contracts;
using Twitter.Service.Contracts;

namespace Twitter.Service.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidatorWrapper _validatorWrapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper, IValidatorWrapper validatorWrapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorWrapper = validatorWrapper;
        }
        public async Task<Author> Create(CreatedAuthor author)
        {
            var validationResult = _validatorWrapper.CreatedAuthorValidator.Validate(author);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var authorEntity = new Author();
            _mapper.Map(author, authorEntity);
            await _unitOfWork.AuthorRepository.Create(authorEntity);
            return authorEntity;
        }

        public async Task Delete(Guid id)
        {
            var author = await GetById(id);
            await _unitOfWork.AuthorRepository.Delete(author);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _unitOfWork.AuthorRepository.GetAll();
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _unitOfWork.AuthorRepository.GetById(id);
            if(author == null) 
            {
                throw new NotFoundException($"Author with id {id} is not found");
            }
            return author;
        }

        public async Task Update(Guid id, UpdatedAuthor author)
        {
            var validationResult = _validatorWrapper.UpdatedAuthorValidator.Validate(author);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var authorEntity = await GetById(id);
            _mapper.Map(author, authorEntity);
            foreach(var tweet in authorEntity.Tweets)
            {
                tweet.AuthorName = authorEntity.Name;
                tweet.AuthorHandle = authorEntity.Handle;
                tweet.AuthorProfilePicture = authorEntity.ProfilePicture;  
            }
            await _unitOfWork.AuthorRepository.Update(authorEntity);
        }
    }
}
