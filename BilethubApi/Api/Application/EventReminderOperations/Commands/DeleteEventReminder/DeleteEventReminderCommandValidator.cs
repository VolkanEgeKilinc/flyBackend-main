using FluentValidation;

namespace BilethubApi.Api.Application.EventReminderOperations.Commands.DeleteEventReminder;

public class DeleteEventReminderCommandValidator : AbstractValidator<DeleteEventReminderCommand>
{
    public DeleteEventReminderCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.UserId).GreaterThan(0);
    }
}