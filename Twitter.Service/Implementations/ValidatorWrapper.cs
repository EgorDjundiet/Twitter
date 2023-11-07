using FluentValidation;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;
using Twitter.Service.Contracts;
using Twitter.Service.Validators;

namespace Twitter.Service.Implementations
{
    public class ValidatorWrapper : IValidatorWrapper
    {
        private readonly AbstractValidator<CreatedTweet> _createdTweetValidator;
        private readonly AbstractValidator<UpdatedTweet> _updatedTweetValidator;
        private readonly AbstractValidator<CreatedAuthor> _createdAuthorValidator; 
        private readonly AbstractValidator<UpdatedAuthor> _updatedAuthorValidator;
        public ValidatorWrapper()
        {
            _createdTweetValidator = new CreatedTweetValidator();
            _updatedTweetValidator = new UpdatedTweetValidator();
            _createdAuthorValidator = new CreatedAuthorValidator();
            _updatedAuthorValidator = new UpdatedAuthorValidator();
        }

        public AbstractValidator<CreatedTweet> CreatedTweetValidator => _createdTweetValidator;

        public AbstractValidator<UpdatedTweet> UpdatedTweetValidator => _updatedTweetValidator;

        public AbstractValidator<CreatedAuthor> CreatedAuthorValidator => _createdAuthorValidator;

        public AbstractValidator<UpdatedAuthor> UpdatedAuthorValidator => _updatedAuthorValidator;
    }
}
