using BilethubApi.Api.Enum;

namespace BilethubApi.Api.Application.CouponOperations.Queries.GetCouponsByEvent;

public class GetCouponsByEventViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int Quota { get; set; }
    public int Used { get; set; }
    public DateTime Date { get; set; }
    public double Discount { get; set; }
    public double TotalDiscount { get; set; }
    public DiscountType DiscountType { get; set; }
    public bool Status { get; set; } = true;
}