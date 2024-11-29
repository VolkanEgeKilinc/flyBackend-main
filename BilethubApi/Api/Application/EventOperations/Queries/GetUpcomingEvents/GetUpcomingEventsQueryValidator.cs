using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetUpcomingEvents;

public class GetUpcomingEventsQueryValidator : AbstractValidator<GetUpcomingEventsQuery>
{
    public GetUpcomingEventsQueryValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}