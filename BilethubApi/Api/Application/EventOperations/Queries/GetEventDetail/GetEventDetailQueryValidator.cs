using FluentValidation;

namespace BilethubApi.Api.Application.EventOperations.Queries.GetEventDetail;

public class GetEventDetailQueryValidator : AbstractValidator<GetEventDetailQuery>
{
    public GetEventDetailQueryValidator()
    {
        RuleFor(query => query.Id).GreaterThan(0);
    }
}