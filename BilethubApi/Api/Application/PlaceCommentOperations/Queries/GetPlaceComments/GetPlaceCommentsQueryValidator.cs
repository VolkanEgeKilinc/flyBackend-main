using FluentValidation;

namespace BilethubApi.Api.Application.PlaceCommentOperations.Queries.GetPlaceComments;

public class GetPlaceCommentsQueryValidator : AbstractValidator<GetPlaceCommentsQuery>
{
    public GetPlaceCommentsQueryValidator()
    {
        RuleFor(query => query.PlaceId).GreaterThan(0);
    }
}