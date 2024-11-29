using FluentValidation;

namespace BilethubApi.Api.Application.CouponOperations.Commands.CreateCoupon;

public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
{
    public CreateCouponCommandValidator()
    {
        RuleFor(command => command.Model.EventId).GreaterThan(0);
        RuleFor(command => command.Model.Title).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Code).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Quota).GreaterThan(0);
        RuleFor(command => command.Model.Discount).GreaterThan(0);
        RuleFor(command => command.Model.DiscountType).NotEmpty();
    }
}