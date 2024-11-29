using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetAdminEventDetail;

public class GetAdminEventDetailQueryValidator : AbstractValidator<GetAdminEventDetailQuery>
{
    public GetAdminEventDetailQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
    }
}