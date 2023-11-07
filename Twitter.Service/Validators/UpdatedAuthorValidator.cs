using FluentValidation;
using Twitter.Domain.UpdatedModels;

namespace Twitter.Service.Validators
{
    public class UpdatedAuthorValidator : AbstractValidator<UpdatedAuthor>
    {
        public UpdatedAuthorValidator()
        {
            RuleFor(ua => ua.Name)
                .NotEmpty().WithMessage("Author name is required")
                .Length(0, 50).WithMessage("Author name is limited by 50 characters");

            RuleFor(ua => ua.Handle)
                .NotEmpty().WithMessage("Author handle is required");

            RuleFor(ua => ua.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author email is required")
                .EmailAddress().WithMessage("Author email has uncorrect format");

            RuleFor(ua => ua.Website)
                .Length(0, 100).WithMessage("Author website is limited by 100 characters");

            RuleFor(ua => ua.Bio)
                .Length(0, 160).WithMessage("Author bio is limited by 160 characters");

            RuleFor(ua => ua.Location)
                .Length(0, 30).WithMessage("Author location is limited by 30 characters");

            RuleFor(ua => ua.BirthDate)
                .NotEmpty().WithMessage("Author birth date is required")
                .Must(ca => ca < DateTime.UtcNow).WithMessage("Author birth date must be earlier than now date");
        }
    }
}
