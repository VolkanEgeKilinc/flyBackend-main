using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetGenresByEventCategory;

public class GetGenresByEventCategoryQueryValidator : AbstractValidator<GetGenresByEventCategoryQuery>
{
    public GetGenresByEventCategoryQueryValidator()
    {
        RuleFor(query => query.EventCategoryId).GreaterThan(0);
    }
}