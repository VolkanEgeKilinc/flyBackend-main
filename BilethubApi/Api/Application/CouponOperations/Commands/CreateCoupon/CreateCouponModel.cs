using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.CouponOperations.Commands.CreateCoupon;

public class CreateCouponModel
{
    public int EventId { get; set; }
    public string Title { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int Quota { get; set; }
    public double Discount { get; set; }
    public DiscountType DiscountType { get; set; }
}