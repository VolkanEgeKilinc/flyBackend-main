using FluentValidation;

namespace BilethubApi.Api.Application.TicketCategoryOperations.Queries.GetAdminEventTicketCategories;

public class GetAdminEventTicketCategoriesQueryValidator : AbstractValidator<GetAdminEventTicketCategoriesQuery>
{
    public GetAdminEventTicketCategoriesQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
    }
}