using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Commands.DeleteTicket;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator(){
        RuleFor(command => command.Id).GreaterThan(0);
    }
}