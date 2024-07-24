using FluentValidation;
using PillReminder.Communication.remedies.requests;

namespace PillReminderApplication.Validators
{
    public class RemedyValidator: AbstractValidator<RemedyJsonRequest>
    {
        public RemedyValidator()
        {
            RuleFor(remedy => remedy.UserId).NotEmpty().WithMessage("user id is required");
            RuleFor(remedy => remedy.UsagePeriod).NotEmpty().WithMessage("usage period is required");
            RuleFor(remedy => remedy.ScheduledHours.Count).GreaterThan(0).WithMessage("Need 1 or more scheduled hours");
            RuleFor(remedy => remedy.RemedyName).NotEmpty().WithMessage("remedy name is required");
            RuleFor(remedy => remedy.RemedyDosage).NotEmpty().WithMessage("remedy dosage is required");
        }
    }
}
