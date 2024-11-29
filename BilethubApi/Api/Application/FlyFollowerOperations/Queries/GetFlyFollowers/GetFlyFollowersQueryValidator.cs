using FluentValidation;

namespace BilethubApi.Api.Application.ArtistFollowerOperations.Queries.GetArtistFollowers;

public class GetArtistFollowersQueryValidator : AbstractValidator<GetArtistFollowersQuery>
{
    public GetArtistFollowersQueryValidator()
    {
        RuleFor(query => query.ArtistId).GreaterThan(0);
    }
}