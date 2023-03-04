using FluentValidation;
using Willis.Afi.Registration.Api.Models;

namespace Willis.Afi.Registration.Api.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
        }
    }
}
