using FluentValidation;

namespace BilethubApi.Api.Application.ArtistOperations.Queries.GetArtistDetail;

public class GetArtistDetailQueryValidator : AbstractValidator<GetArtistDetailQuery>
{
    public GetArtistDetailQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}