using FluentValidation;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Contracts
{
    public interface IValidatorWrapper
    {
        AbstractValidator<CreatedTweet> CreatedTweetValidator { get; }
        AbstractValidator<UpdatedTweet> UpdatedTweetValidator { get; }
        AbstractValidator<CreatedAuthor> CreatedAuthorValidator { get; }
        AbstractValidator<UpdatedAuthor> UpdatedAuthorValidator { get; }
    }
}
