using FluentValidation;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Validators
{
    public class UpdatedTweetValidator : AbstractValidator<UpdatedTweet>
    {
        public UpdatedTweetValidator()
        {
            RuleFor(t => t.Text).NotEmpty().WithMessage("Text field must not be empty");
            RuleFor(t => t.Schedule).Must(s => s is null || s.Value > DateTime.UtcNow).WithMessage("Date field must no be earlier than now date");
        }
    }
}
