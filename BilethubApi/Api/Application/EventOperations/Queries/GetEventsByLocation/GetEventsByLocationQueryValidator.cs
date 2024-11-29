using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventsByLocation;

public class GetEventsByLocationQueryValidator : AbstractValidator<GetEventsByLocationQuery>
{
    public GetEventsByLocationQueryValidator()
    {
        RuleFor(query => query.Location.X).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
        RuleFor(query => query.Location.Y).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
    }
}