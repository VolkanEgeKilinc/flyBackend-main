using FluentValidation;

namespace BilethubApi.Api.Application.EventReminderOperations.Commands.CreateEventReminder;

public class CreateEventReminderCommandValidator : AbstractValidator<CreateEventReminderCommand>
{
    public CreateEventReminderCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}