using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetGuestTickets;

public class GetGuestTicketsQueryValidator : AbstractValidator<GetGuestTicketsQuery>
{
    public GetGuestTicketsQueryValidator()
    {
        RuleFor(query => query.EventId).GreaterThan(0);
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}