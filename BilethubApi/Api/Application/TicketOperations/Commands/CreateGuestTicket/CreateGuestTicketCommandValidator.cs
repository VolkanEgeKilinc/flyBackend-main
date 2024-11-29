using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Commands.CreateGuestTicket;

public class CreateGuestTicketCommandValidator : AbstractValidator<CreateGuestTicketCommand>
{
    public CreateGuestTicketCommandValidator()
    {
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.TicketCategoryId).GreaterThan(0);
    }
}