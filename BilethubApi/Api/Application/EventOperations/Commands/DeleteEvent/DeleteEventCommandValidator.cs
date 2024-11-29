using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Commands.DeleteEvent;

public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
{
    public DeleteEventCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}