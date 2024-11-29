using FluentValidation;

namespace BilethubApi.Api.Application.PlaceFollowerOperations.Queries.GetPlaceFollowers;

public class GetPlaceFollowersQueryValidator : AbstractValidator<GetPlaceFollowersQuery>
{
    public GetPlaceFollowersQueryValidator()
    {
        RuleFor(query => query.PlaceId).GreaterThan(0);
    }
}