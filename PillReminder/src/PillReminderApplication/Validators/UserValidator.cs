using FluentValidation;
using PillReminder.Comunication.users.Requests;

namespace PillReminderApplication.Validators
{
    public class UserValidator : AbstractValidator<UserJsonRequest>
    {
        public UserValidator()
        {
            {
                RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage("Password must have 8 or more characters");
                RuleFor(user => user.Email).NotEmpty().WithMessage("Email must be provided");
                RuleFor(user => user.Name).NotEmpty().WithMessage("Name must be provided");
            }
        }

    }
}
