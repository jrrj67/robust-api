using FluentValidation;
using Robust.Domain.Entities;

namespace Robust.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Entity can't be empty.")
                .NotNull().WithMessage("Entity can't be null.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name can't be null.")
                .NotEmpty().WithMessage("Name can't be empty.")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters.")
                .MaximumLength(80).WithMessage("Name can't have more than 80 characters.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email can't be null.")
                .NotEmpty().WithMessage("Email can't be empty.")
                .MinimumLength(10).WithMessage("Name must have at least 10 characters.")
                .MaximumLength(180).WithMessage("Email can't have more than 80 characters.")
                .EmailAddress().WithMessage("Email must be valid.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password can't be null.")
                .NotEmpty().WithMessage("Password can't be empty.")
                .MinimumLength(6).WithMessage("Password must have at least 6 characters.")
                .MaximumLength(255).WithMessage("Password can't have more than 255 characters.");
        }
    }
}
