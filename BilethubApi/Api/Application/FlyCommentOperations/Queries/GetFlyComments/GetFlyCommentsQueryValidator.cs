using FluentValidation;

namespace BilethubApi.Api.Application.ArtistCommentOperations.Queries.GetArtistComments;

public class GetArtistCommentsQueryValidator : AbstractValidator<GetArtistCommentsQuery>
{
    public GetArtistCommentsQueryValidator()
    {
        RuleFor(query => query.ArtistId).GreaterThan(0);
    }
}