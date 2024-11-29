using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateTicket;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.TicketCategoryId).GreaterThan(0);
    }
}