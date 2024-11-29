using FluentValidation;

namespace BilethubApi.Api.Application.TicketOperations.Queries.GetTicketsByUser;

public class GetTicketsByUserQueryValidator : AbstractValidator<GetTicketsByUserQuery>
{
    public GetTicketsByUserQueryValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}