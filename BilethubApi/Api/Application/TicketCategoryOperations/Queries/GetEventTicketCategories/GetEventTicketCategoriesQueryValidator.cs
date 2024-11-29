using FluentValidation;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetEventTicketCategories;

public class GetEventTicketCategoriesQueryValidator : AbstractValidator<GetEventTicketCategoriesQuery>
{
    public GetEventTicketCategoriesQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
    }
}