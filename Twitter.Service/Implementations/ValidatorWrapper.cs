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
        public ValidatorWrapper()
        {
            _createdTweetValidator = new CreatedTweetValidator();
            _updatedTweetValidator = new UpdatedTweetValidator();
        }

        public AbstractValidator<CreatedTweet> CreatedTweetValidator => _createdTweetValidator;

        public AbstractValidator<UpdatedTweet> UpdatedTweetValidator => _updatedTweetValidator;
    }
}
