using FluentValidation;

namespace BilethubApi.Api.Application.CouponOperations.Queries.GetCouponsByEvent;

public class GetCouponsByEventQueryValidator : AbstractValidator<GetCouponsByEventQuery>
{
    public GetCouponsByEventQueryValidator()
    {
        RuleFor(query => query.UserId).GreaterThan(0);
    }
}