using AutoMapper;
using BilethubApi.Api.DbOperations;

namespace BilethubApi.Api.Application.CouponOperations.Commands.UpdateCoupon;

public class UpdateCouponCommand
{
    private IBilethubDbContext _context;

    public int Id { get; set; }
    public UpdateCouponModel Model { get; set; } = null!;

    public UpdateCouponCommand(IBilethubDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var coupon = _context.Coupons.FirstOrDefault(x => x.Id == Id);
        if (coupon is null)
            throw new InvalidOperationException("Coupon is not found!");

        coupon.Status = Model.Status != default ? Model.Status : coupon.Status;

        _context.SaveChanges();
    }
}