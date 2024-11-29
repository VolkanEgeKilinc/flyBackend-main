using FluentValidation;

namespace BilethubApi.Api.Application.CouponOperations.Commands.UpdateCoupon;

public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>{
    public UpdateCouponCommandValidator(){
        RuleFor(command => command.Model.Status).NotEmpty();
    }
}