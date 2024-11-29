using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Commands.UpdateTicket;

public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.UserId).GreaterThan(0);
        RuleFor(command => command.Model.CouponId).GreaterThan(0);
    }
}