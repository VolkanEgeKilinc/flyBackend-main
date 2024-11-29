using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketByToken;

public class GetTicketByTokenQueryValidator : AbstractValidator<GetTicketByTokenQuery>
{
    public GetTicketByTokenQueryValidator()
    {
        RuleFor(command => command.EventId).GreaterThan(0);
        RuleFor(command => command.Token).Length(64);
    }
}