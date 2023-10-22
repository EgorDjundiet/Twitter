using FluentValidation;
using Twitter.Domain.CreatedModels;

namespace Twitter.Service.Validators
{
    public class CreatedTweetValidator : AbstractValidator<CreatedTweet>
    {
        public CreatedTweetValidator()
        {
            RuleFor(t => t.Text).NotEmpty().WithMessage("Text field must not be empty");
            RuleFor(t => t.Schedule).Must(s => s is null || s.Value > DateTime.UtcNow).WithMessage("Date field must no be earlier than now date");
        }
    }
}
