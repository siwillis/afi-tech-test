using FluentValidation;
using Willis.Afi.Registration.Api.Models;

namespace Willis.Afi.Registration.Api.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(3, 50);
            RuleFor(x => x.LastName).NotNull().Length(3, 50);
            RuleFor(x => x.DateOfBirth).NotNull().When(x => string.IsNullOrEmpty(x.EmailAddress));
            RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.Today.AddYears(-18)).When(x => x.DateOfBirth != null).WithMessage("'Date Of Birth' must make customer at least 18 years old.");
            RuleFor(x => x.EmailAddress).NotEmpty().When(x => x.DateOfBirth is null);
            RuleFor(x => x.EmailAddress).Matches("[a-zA-Z0-9]{4}@[a-zA-Z0-9]{2}").When(x => !string.IsNullOrEmpty(x.EmailAddress));
            RuleFor(x => x.ReferenceNumber).NotNull().Matches(@"^[A-Z]{2}-[0-9]{6}$");
        }
    }
}
