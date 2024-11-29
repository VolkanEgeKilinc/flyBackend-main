using FluentValidation;

namespace BilethubApi.Api.Application.PlaceOperations.Queries.GetPlaceDetail;

public class GetPlaceDetailQueryValidator : AbstractValidator<GetPlaceDetailQuery>
{
    public GetPlaceDetailQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}