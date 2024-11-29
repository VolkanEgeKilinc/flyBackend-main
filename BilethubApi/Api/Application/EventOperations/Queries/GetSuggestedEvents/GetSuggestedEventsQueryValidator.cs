using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetSuggestedEvents;

public class GetSuggestedEventsQueryValidator : AbstractValidator<GetSuggestedEventsQuery>
{
    public GetSuggestedEventsQueryValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}