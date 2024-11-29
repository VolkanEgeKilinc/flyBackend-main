using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByEvent;

public class GetTicketsByEventQueryValidator : AbstractValidator<GetTicketsByEventQuery>
{
    public GetTicketsByEventQueryValidator()
    {
        RuleFor(query => query.EventId).GreaterThan(0);
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}